using DreamGallery.Data.Repositories;
using DreamGallery.Domain.Entities;
using DreamGallery.Domain.Enums;
using DreamGallery.Service.DTOs.Artist;
using DreamGallery.Service.DTOs.User;
using DreamGallery.Service.Interfaces;
using DreamGallery.Service.Services;

namespace DreamGallery.Presentation.Presentation
{
    public class UserInterface
    {
        public async Task RunCodeAsync()
        {
            Console.WriteLine("\r\n8888888b.                                           .d8888b.           888 888                           \r\n888  \"Y88b                                         d88P  Y88b          888 888                           \r\n888    888                                         888    888          888 888                           \r\n888    888 888d888  .d88b.   8888b.  88888b.d88b.  888         8888b.  888 888  .d88b.  888d888 888  888 \r\n888    888 888P\"   d8P  Y8b     \"88b 888 \"888 \"88b 888  88888     \"88b 888 888 d8P  Y8b 888P\"   888  888 \r\n888    888 888     88888888 .d888888 888  888  888 888    888 .d888888 888 888 88888888 888     888  888 \r\n888  .d88P 888     Y8b.     888  888 888  888  888 Y88b  d88P 888  888 888 888 Y8b.     888     Y88b 888 \r\n8888888P\"  888      \"Y8888  \"Y888888 888  888  888  \"Y8888P88 \"Y888888 888 888  \"Y8888  888      \"Y88888 \r\n                                                                                                     888 \r\n                                                                                                Y8b d88P \r\n                                                                                                 \"Y88P\"  \r\n");
            while (true)
            {
                Console.WriteLine("Sign Up => 1");
                Console.WriteLine("Login => 2");
                int num = int.Parse(Console.ReadLine());
                switch(num)
                {
                    case 1:
                        RegistrationService registrationService = new RegistrationService();
                        Registration registration = new Registration();
                        Console.WriteLine("Enter Your Firstname");
                        registration.FirstName = Console.ReadLine();
                        Console.WriteLine("Enter Your Lastname");
                        registration.LastName = Console.ReadLine();
                        Console.WriteLine("Enter Your Email address");
                        registration.Email = Console.ReadLine();
                        Console.WriteLine("Enter Your Password");
                        registration.Password = Console.ReadLine();
                        Console.WriteLine("Enter Your PhoneNumber");
                        registration.PhoneNumber = Console.ReadLine();
                        Console.WriteLine("Sign up as User => 1");
                        Console.WriteLine("Sign up as Artist => 2");
                        int num2 = int.Parse(Console.ReadLine());
                        switch (num2)
                        {
                            case 1:
                                var user = new UserForCreationDto();
                                user.FirstName = registration.FirstName;
                                user.LastName = registration.LastName;
                                user.Email = registration.Email;
                                user.Password = registration.Password;
                                user.PhoneNumber = registration.Password;
                                Console.WriteLine("To'lov ma'lumotlaringizni Kiriting");
                                Console.WriteLine("1 => Payme");
                                Console.WriteLine("2 => Paypal");
                                Console.WriteLine("3 => Click");
                                Console.WriteLine("4 => Oson");
                                user.PaymentMethod = (Method)Enum.Parse(typeof(Method), Console.ReadLine());
                                Console.WriteLine("Hisobingizdagi Balansni kiritng");
                                user.Balance = decimal.Parse(Console.ReadLine());
                                UserService ServiceForUser = new UserService();
                                await ServiceForUser.CreateAsync(user);
                                break;
                                case 2:
                                var artist = new ArtistForCreationDto();
                                artist.FirstName = registration.FirstName;
                                artist.LastName = registration.LastName;
                                artist.Email = registration.Email;
                                artist.Password = registration.Password;
                                artist.PhoneNumber = registration.Password;
                                artist.Balance = 0;
                                ArtistService artistService = new ArtistService();
                                await artistService.CreateAsync(artist);
                                break;

                        }
                        break;
                    case 2:
                        var Auth = new Authentication();
                        break;
                }
            }
        }
    }
}
