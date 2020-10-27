using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Hotel.Models;

namespace Hotel.Data
{
    public static class DbInitializer
    {
        public static void Initialize(HotelContext context)
        {
            context.Database.EnsureCreated();

            // Look for any BookingRooms.
            if (context.Customers.Any())
            {
                return;   // DB0000 has been seeded
            }

            var facilitiesList = new FacilitiesList[]
            {
                new FacilitiesList{FacilityDesc="TV"},
                new FacilitiesList{FacilityDesc="Aire acondicionado"},
                new FacilitiesList{FacilityDesc="Telefono"},
                new FacilitiesList{FacilityDesc="Internet"},
                new FacilitiesList{FacilityDesc="Room Services"},
                new FacilitiesList{FacilityDesc="Caja fuerte"}
            };

            foreach(FacilitiesList f in facilitiesList)
            {
                context.FacilitiesLists.Add(f);               
            }
            context.SaveChanges();

            var roomTypes = new RoomTypes[]
            {
                new RoomTypes{ RoomType="Suite" },
                new RoomTypes{ RoomType="Suite Presidencial" },
                new RoomTypes{ RoomType="Ejecutivo" },
                new RoomTypes{ RoomType="Sencilla" },
                new RoomTypes{ RoomType="Doble" },
                new RoomTypes{ RoomType="Triple" },
                new RoomTypes{ RoomType="Cuadruple" }
            };

            foreach(RoomTypes r in roomTypes)
            {
                context.RoomTypes.Add(r);
            }
            context.SaveChanges();

            var roomBands = new RoomBand[]
            {
                new RoomBand{BandDesc= "Band Desc 1"},
                new RoomBand{BandDesc= "Band Desc 2"},
                new RoomBand{BandDesc= "Band Desc 3"},
                new RoomBand{BandDesc= "Band Desc 4"},
                new RoomBand{BandDesc= "Band Desc 5"}
            };

            foreach(RoomBand r in roomBands)
            {
                context.RoomBands.Add(r);
            }
            context.SaveChanges();

            var roomPrices = new RoomPrices[]
            {
                new RoomPrices{ RoomPrice = 200},
                new RoomPrices{ RoomPrice = 300},
                new RoomPrices{ RoomPrice = 400},
                new RoomPrices{ RoomPrice = 500},
                new RoomPrices{ RoomPrice = 700},
                new RoomPrices{ RoomPrice = 1000}
            };

            foreach(RoomPrices r in roomPrices)
            {
                context.RoomPrices.Add(r);
            }
            context.SaveChanges();

            var rooms = new Room[]
            {
                new Room{RoomTypesID = 3, RoomBandID = 2, RoomPricesID = 1, Floor = "Segundo", AdditionalNotes = ""},
                new Room{RoomTypesID = 2, RoomBandID = 3, RoomPricesID = 6, Floor = "Tercero", AdditionalNotes = "fantasma de Caterville"}
            };
            
            foreach(Room r in rooms)
            {
                context.Rooms.Add(r);
            }
            context.SaveChanges();

            var roomsFacilities = new RoomsFacilities[]
            {
                new RoomsFacilities{RoomID=1, FacilitiesListID=2, FacilityDetails="Frio y caliente"},
                new RoomsFacilities{RoomID=1, FacilitiesListID=1, FacilityDetails="Facilidad facil"},
                new RoomsFacilities{RoomID=2, FacilitiesListID=3, FacilityDetails="Otra facilidad"}
            };

            foreach(RoomsFacilities r in roomsFacilities)
            {
                context.RoomsFacilities.Add(r);
            }
            context.SaveChanges();

            var customers = new Customer[]
            {
                new Customer { CustomerTitle = "Sr.",   CustomerForenames = "Carson",           CustomerSurnames = "Alexander",         CustomerDOB = DateTime.Parse("2000-09-01"),
                    CustomerAddressStreet = "Bugambilias 117",  CustomerAddressTown = "CMDX",   CustomerAddressCounty = "MX",          CustomerAddressPostalCode = "20000",
                    CustomerHomePhone = "4495851000",   CustomerWorkPhone = "",                 CustomerMobilePhone = "4491091070",     CustomerEmail ="abc@email.com" },
                new Customer { CustomerTitle = "Sra.",  CustomerForenames = "Meredith",         CustomerSurnames = "Alonso",            CustomerDOB = DateTime.Parse("2002-09-01"),
                    CustomerAddressStreet = "Sonora 217",       CustomerAddressTown = "Chilpancingo", CustomerAddressCounty = "Canada", CustomerAddressPostalCode = "97000",
                    CustomerHomePhone = "4495851010",   CustomerWorkPhone = "4750501000",       CustomerMobilePhone = "4491091060",     CustomerEmail ="def@email.com" },
                new Customer { CustomerTitle = "",      CustomerForenames = "Arturo",           CustomerSurnames = "Anand",             CustomerDOB = DateTime.Parse("2003-09-01"),
                    CustomerAddressStreet = "Chafita 37",       CustomerAddressTown = "Venecia", CustomerAddressCounty = "Ecuador",    CustomerAddressPostalCode = "89000",
                    CustomerHomePhone = "4495851020",   CustomerWorkPhone = "4750501010",       CustomerMobilePhone = "4491091050",     CustomerEmail ="ghi@email.com" },
                new Customer { CustomerTitle = "Srto.", CustomerForenames = "Gytis",            CustomerSurnames = "Barzdukas",         CustomerDOB = DateTime.Parse("2002-09-01"),
                    CustomerAddressStreet = "Tepic 104",        CustomerAddressTown = "Timbuctu", CustomerAddressCounty = "Rusia",     CustomerAddressPostalCode = "25400",
                    CustomerHomePhone = "4495851030",   CustomerWorkPhone = "4750501020",       CustomerMobilePhone = "4491091040",     CustomerEmail ="jkl@email.com" },
                new Customer { CustomerTitle = "Srta.", CustomerForenames = "Yan",              CustomerSurnames = "Li",                CustomerDOB = DateTime.Parse("2002-09-01"),
                    CustomerAddressStreet = "Siempre viva 106", CustomerAddressTown = "Lmao",   CustomerAddressCounty = "Panama",      CustomerAddressPostalCode = "54000",
                    CustomerHomePhone = "4495851040",   CustomerWorkPhone = "",                 CustomerMobilePhone = "4491091030",     CustomerEmail ="mno@email.com" },
                new Customer { CustomerTitle = "Sra.",  CustomerForenames = "Peggy",            CustomerSurnames = "Justice",           CustomerDOB = DateTime.Parse("2001-09-01"),
                    CustomerAddressStreet = "Chona 107",        CustomerAddressTown = "Michoacan", CustomerAddressCounty = "El Salvador", CustomerAddressPostalCode = "20050",
                    CustomerHomePhone = "4495851050",   CustomerWorkPhone = "4750501030",       CustomerMobilePhone = "4491091020",     CustomerEmail ="pqr@email.com" },
                new Customer { CustomerTitle = "Sra.",  CustomerForenames = "Lara",             CustomerSurnames = "Norman",            CustomerDOB = DateTime.Parse("2003-09-01"),
                    CustomerAddressStreet = "La Lona 119",      CustomerAddressTown = "Panfilo Natera", CustomerAddressCounty = "Chile", CustomerAddressPostalCode = "10400",
                    CustomerHomePhone = "4495851060",   CustomerWorkPhone = "",                 CustomerMobilePhone = "4491091010",     CustomerEmail ="stu@email.com" },
                new Customer { CustomerTitle = "Sr.",   CustomerForenames = "Nino",             CustomerSurnames = "Olivetto",          CustomerDOB = DateTime.Parse("1995-09-01"),
                    CustomerAddressStreet = "De Martita 51",    CustomerAddressTown = "ETTE",   CustomerAddressCounty = "Argentina",   CustomerAddressPostalCode = "5000",
                    CustomerHomePhone = "4495851070",   CustomerWorkPhone = "4750501040",       CustomerMobilePhone = "4491091000",     CustomerEmail ="xyz@email.com" }
            };

            foreach (Customer c in customers)
            {
                context.Customers.Add(c);
            }
            context.SaveChanges();

            var bookings = new Booking[]
            {
                new Booking {CustomerID = 5,    DateBookingMade = DateTime.Parse("2020-10-20"),     TimeBookingMade = DateTime.Parse("15:05"),
                    BookedStartDate = DateTime.Parse("2020-10-23"),     BookedEndDate = DateTime.Parse("2020-10-25"),
                    TotalPaymentDueDate = DateTime.Parse("2020-10-23"),     TotalPaymentDueAmount = 2400,   TotalPaymentMadeOn = DateTime.Parse("2020-10-21"), BookingComments = ""},
                new Booking {CustomerID = 1,    DateBookingMade = DateTime.Parse("2020-10-10"),     TimeBookingMade = DateTime.Parse("17:00"),
                    BookedStartDate = DateTime.Parse("2020-10-03"),     BookedEndDate = DateTime.Parse("2020-10-05"),
                    TotalPaymentDueDate = DateTime.Parse("2021-10-20"),     TotalPaymentDueAmount = 2400,   TotalPaymentMadeOn = DateTime.Parse("2020-10-07"), BookingComments = "un dia pagara"},
                new Booking {CustomerID = 3,    DateBookingMade = DateTime.Parse("2020-10-15"),      TimeBookingMade = DateTime.Parse("12:21"),
                    BookedStartDate = DateTime.Parse("2020-10-02"),     BookedEndDate = DateTime.Parse("2020-10-05"),
                    TotalPaymentDueDate = DateTime.Parse("2020-10-13"),     TotalPaymentDueAmount = 2400,   TotalPaymentMadeOn = DateTime.Parse("2020-10-22"), BookingComments = "reservacion en moe's"}
            };

            foreach (Booking b in bookings)
            {
                context.Bookings.Add(b);
            }
            context.SaveChanges();

            var paymentMethods = new PaymentMethods[]
            {
                new PaymentMethods{PaymentMethodID=1, PaymentMethod="Efectivo"},
                new PaymentMethods{PaymentMethodID=2, PaymentMethod="Tarjeta Debito"},
                new PaymentMethods{PaymentMethodID=3, PaymentMethod="Tarjeta Credito"},
                new PaymentMethods{PaymentMethodID=4, PaymentMethod="Transferencia"},
                new PaymentMethods{PaymentMethodID=5, PaymentMethod="PayPal"}
            };

            foreach(PaymentMethods p in paymentMethods)
            {
                context.PaymentMethods.Add(p);
            }
            context.SaveChanges();

            var payments = new Payment[]
            {
                new Payment{BookingID=1, CustomerID = 2, PaymentMethodsID = 1, PaymentAmount = 200, PaymentComments= "Gracias por su eleccion"},
                new Payment{BookingID=2, CustomerID = 1, PaymentMethodsID = 2, PaymentAmount = 400, PaymentComments= "Gracias por su eleccion"},
                new Payment{BookingID=1, CustomerID = 5, PaymentMethodsID = 3, PaymentAmount = 600, PaymentComments= "Gracias por su eleccion"},
                new Payment{BookingID=3, CustomerID = 3, PaymentMethodsID = 4, PaymentAmount = 800, PaymentComments= "Gracias por su eleccion"}
            };

            foreach(Payment p in payments)
            {
                context.Payments.Add(p);
            }
            context.SaveChanges();

            var guests = new Guest[]
            {
                new Guest { GuestTitle = "Srta.",   GuestForenames = "Kim",     GuestSurnames = "Abercrombie",  GuestDOB = DateTime.Parse("1995-03-11") ,
                    GuestAddressStreet = "Bugambilias 117",  GuestAddressTown = "CMDX",   GuestAddressCounty = "MX",          GuestAddressPostalCode = "20000",
                    GuestContactPhone = "4491091070"},
                new Guest { GuestTitle = "Sr.",   GuestForenames = "Carson",    GuestSurnames = "Alexander",    GuestDOB = DateTime.Parse("2000-09-01"),
                    GuestAddressStreet = "Bugambilias 117",  GuestAddressTown = "CMDX",   GuestAddressCounty = "MX",          GuestAddressPostalCode = "20200",
                    GuestContactPhone = "4495851000"},
                new Guest { GuestTitle = "Sr.",     GuestForenames = "Fadi",    GuestSurnames = "Fakhouri",     GuestDOB = DateTime.Parse("2002-07-06"),
                    GuestAddressStreet = "Kumbala 77",      GuestAddressTown = "Maracas",   GuestAddressCounty = "Maracas",          GuestAddressPostalCode = "25400",
                    GuestContactPhone = "4495851090"},
                new Guest { GuestTitle = "Sr.",     GuestForenames = "Roger",   GuestSurnames = "Harui",        GuestDOB = DateTime.Parse("1998-07-01"),
                    GuestAddressStreet = "La corona 44",    GuestAddressTown = "Serindipia",   GuestAddressCounty = "Timbuctu",   GuestAddressPostalCode = "68000",
                    GuestContactPhone = "4495851011"},
                new Guest { GuestTitle = "Sra.",    GuestForenames = "Candace", GuestSurnames = "Kapoor",       GuestDOB = DateTime.Parse("2001-01-15"),
                    GuestAddressStreet = "El cerro de abajo 102",  GuestAddressTown = "Zudoh",   GuestAddressCounty = "Rusia",          GuestAddressPostalCode = "60540",
                    GuestContactPhone = "4495851022"},
                new Guest { GuestTitle = "Sr.",     GuestForenames = "Roger",   GuestSurnames = "Zheng",        GuestDOB = DateTime.Parse("2004-02-12"),
                    GuestAddressStreet = "Florida 817",  GuestAddressTown = "Grosella",   GuestAddressCounty = "Casares",          GuestAddressPostalCode = "95030",
                    GuestContactPhone = "4495851033"}
            };

            foreach (Guest g in guests)
            {
                context.Guests.Add(g);
            }
            context.SaveChanges();

            var bookingsRooms = new BookingRoom[]
            {
                new BookingRoom{ BookingID = 1, RoomID = 1, GuestID = 5},
                new BookingRoom{ BookingID = 2, RoomID = 1, GuestID = 4},
                new BookingRoom{ BookingID = 2, RoomID = 2, GuestID = 3},
                new BookingRoom{ BookingID = 1, RoomID = 2, GuestID = 2}
            };

            foreach (BookingRoom br in bookingsRooms)
            {
                context.BookingRooms.Add(br);
            }
            context.SaveChanges();

        }
    }
}