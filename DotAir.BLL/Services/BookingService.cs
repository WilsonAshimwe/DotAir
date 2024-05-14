using DotAir.BLL.Infrastructure;
using DotAir.BLL.Interfaces;
using DotAir.BLL.Templates;
using DotAir.Domain.Entities;
using DotAir.Domain.Enums;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Mvc;
using SelectPdf;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace DotAir.BLL.Services
{
    public class BookingService(
        ICustomerRepository _customerRepository, 
        IFlightRepository _flightRepository, 
        IBookingRepository _bookingRepository,
        Mailer _mailer,
        HtmlRenderer _htmlRenderer,
        HtmlToPdf _htmlToPdf
    )
    {
        public Booking Register(int customerId, int flightId)
        {
            // client existe ? // CustomerRepo
            Customer? customer = _customerRepository.Find(customerId);
            // flight existe ? // FlightRepo + Plane + Bookings
            Flight? flight = _flightRepository.FindWithBookingsAndPlane(flightId);
            if (customer is null || flight is null)
            {
                throw new ValidationException("Le vol ou le client n'existe pas");
            }

            Validate(customer, flight);

            int price = CalculatePrice(flight);

            Booking b = new Booking
            {
                Reference = Guid.NewGuid().ToString(),
                CustomerId = customerId,
                Price = price,
                ExtraLuggageNb = 0,
                CancelInsurance = false,
                DepartureFlight = flight,
            };

            SendMail(customer, flight, b);

            return _bookingRepository.Add(b);
        }

        private void SendMail(Customer customer, Flight flight, Booking booking)
        {
            string html = _htmlRenderer
                .Render<BookingConfirmationMailTemplate>(new
                {
                    Name = customer.LastName + " " + customer.FirstName,
                    Reference = booking.Reference,
                    ArrivalAirport = flight.ArrivalAirport.City,
                    DepartureAirport = flight.DepartureAirport.City,
                    ArrivalDate = flight.ArrivalDate,
                    DepartureDate = flight.DepartureDate,
                });

            string htmlTicket = _htmlRenderer.Render<TicketTemplate>(new {
                ArrivalAirport = flight.ArrivalAirport.City,
                DepartureAirport = flight.DepartureAirport.City,
                ArrivalDate = flight.ArrivalDate,
                DepartureDate = flight.DepartureDate,
            });
            PdfDocument pdfDocument = _htmlToPdf.ConvertHtmlString(htmlTicket);
            MemoryStream stream = new MemoryStream();
            
            pdfDocument.Save(stream);

            _mailer.Send(customer.Email, "Confirmation de votre réservation", html, new Attachment(stream, "ticket_aller.pdf" ,"application/pdf"));
        }

        private int CalculatePrice(Flight flight)
        {
            // calculer le prix
            int price = flight.BasePrice;

            return price;
        }

        private void Validate(Customer customer, Flight flight)
        {

            // flight dejà parti ? // FlightRepo
            if (flight.DepartureDate < DateTime.Now)
            {
                throw new ValidationException("Le vol est déjà parti");
            }

            // encore de la place ? // FlightRepo + Booking + Plane
            if (flight.Plane.SeatsNb <= flight.Bookings.Count)
            {
                throw new ValidationException("Le vol est complet");
            }

            // status ? // FlightRepo
            if (flight.Status != FlightStatus.Planned)
            {
                throw new ValidationException($"Le vol n'est pas ou plus disponible {flight.Status}");
            }

            // un client ne peut pas reserver 2 fois le meme vol
            if (flight.Bookings.Any(b => b.CustomerId == customer.Id))
            {
                throw new ValidationException($"Le vol a déjà été reservé par cette personne");
            }
        }
    }
}
