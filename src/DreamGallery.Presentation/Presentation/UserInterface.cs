using DreamGallery.Data.Repositories;
using DreamGallery.Domain.Entities;
using DreamGallery.Domain.Enums;
using DreamGallery.Service.DTOs.Artist;
using DreamGallery.Service.DTOs.Artwork;
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
                var artworkService = new ArtworkService();
                var AllArtWorks = await artworkService.GetAllAsync();
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
                                Console.WriteLine($"{user.FirstName} Your account has been created Succesfully");
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
                                Console.WriteLine($"{artist.FirstName} Your account has been created Succesfully");
                                await artistService.CreateAsync(artist);
                                break;

                        }
                        break;
                    case 2:
                        var Auth = new Authentication();
                        Console.WriteLine("Enter Your Email");
                        Auth.Email = Console.ReadLine();
                        Console.WriteLine("Enter Your Password");
                        Auth.Password = Console.ReadLine();

                        var authenticationService = new AuthenticationService();
                        var result = await authenticationService.AuthoriseAsync(Auth);
                        var UserService = new UserService();
                        var Profile = (await UserService.GetAllAsync()).FirstOrDefault(e => e.Email == Auth.Email && e.Password == Auth.Password);
                        switch (result)
                        {
                            case AuthResult.UserAuthenticated:
                                var userLoop = true;
                                while (userLoop)
                                {
                                    Console.WriteLine("1 => See All Artworks");
                                    Console.WriteLine("2 => Search For Artworks");
                                    Console.WriteLine("3 => Buy Artwork");
                                    Console.WriteLine("4 => My Collections");
                                    Console.WriteLine("5 => Update Profile");
                                    Console.WriteLine("6 => See My Profile");
                                    Console.WriteLine("7 => Log out");
                                    int num3 = int.Parse(Console.ReadLine());
                                    ArtworkService artService = new ArtworkService();
                                    ArtistService artistService = new ArtistService();
                                    var selected = await artistService.GetAllAsync();
                                    var AllArtworks = await artService.GetAllAsync();
                                    switch(num3)
                                    {
                                        case 1:
                                            
                                            foreach (var art in AllArtworks)
                                            {
                                                Console.WriteLine("_____________________________________");
                                                Console.WriteLine("Artwork Id: " + art.Id);
                                                Console.WriteLine("Artwork Title: " + art.Title);
                                                var name = selected.FirstOrDefault(e => e.Id == art.ArtistId);
                                                Console.WriteLine("Created By: " + name.FirstName);
                                                Console.WriteLine("Artwork Category: " + art.Category);
                                                Console.WriteLine("Artwork Descripion: " + art.Desciption);
                                                Console.WriteLine("Artwork Price: " + art.Price);
                                                Console.WriteLine("_____________________________________");

                                            }
                                            break;
                                            case 2:
                                            string search = Console.ReadLine();
                                            var SearchResult = AllArtworks.Where(e => e.Title == search);
                                            foreach (var art in SearchResult)
                                            {
                                                Console.WriteLine("_____________________________________");
                                                Console.WriteLine("Artwork Id: " + art.Id);
                                                Console.WriteLine("Artwork Title: " + art.Title);
                                                var name = selected.FirstOrDefault(e => e.Id == art.ArtistId);
                                                Console.WriteLine("Created By: " + name.FirstName);
                                                Console.WriteLine("Artwork Category: " + art.Category);
                                                Console.WriteLine("Artwork Descripion: " + art.Desciption);
                                                Console.WriteLine("Artwork Price: " + art.Price);
                                                Console.WriteLine("_____________________________________");

                                            }
                                            break;
                                            case 3:
                                            Purchase purchase = new Purchase();
                                            PurchaseService purchaseService = new PurchaseService();
                                            Console.WriteLine("Which Artwork do you want to Purchase? Enter The Id Of Art");
                                            purchase.ArtworkId = long.Parse(Console.ReadLine());
                                            purchase.UserId = Profile.Id;
                                            purchase.PurchaseDate = DateTime.UtcNow;
                                            var result2 = await purchaseService.PurchaseAsync(purchase);
                                            var GetArtWorkname = AllArtworks.FirstOrDefault(e => e.Id == result2.ArtworkId);
                                            Console.WriteLine("You successfully purchased " + result2.ArtworkId + " Artwork.");
                                            break;
                                            case 4:
                                            PurchaseService purchaseService2 = new PurchaseService();
                                            var MyCollection = await purchaseService2.GetMyCollectionAsync(Profile.Id);
                                            foreach (var item in MyCollection)
                                            {
                                                var item2 = AllArtworks.Where(e => e.Id == item.ArtworkId);
                                                foreach(var art in item2)
                                                {
                                                    Console.WriteLine("_____________________________________");
                                                    Console.WriteLine("Artwork Id: " + art.Id);
                                                    Console.WriteLine("Artwork Title: " + art.Title);
                                                    var name = selected.FirstOrDefault(e => e.Id == art.ArtistId);
                                                    Console.WriteLine("Created By: " + name.FirstName);
                                                    Console.WriteLine("Artwork Category: " + art.Category);
                                                    Console.WriteLine("Artwork Descripion: " + art.Desciption);
                                                    Console.WriteLine("Artwork Price: " + art.Price);
                                                    Console.WriteLine("_____________________________________");
                                                }
                                            }
                                            break;
                                            case 5:
                                            var UserUpdate = new UserForUpdateDto();
                                            var ServiceUser = new UserService();
                                            UserUpdate.Id = Profile.Id;
                                            Console.WriteLine("Enter Your Firstname");
                                            UserUpdate.FirstName = Console.ReadLine();
                                            Console.WriteLine("Enter Your Lastname");
                                            UserUpdate.LastName = Console.ReadLine();
                                            Console.WriteLine("Enter Your Email address");
                                            UserUpdate.Email = Console.ReadLine();
                                            Console.WriteLine("Enter Your Password");
                                            UserUpdate.Password = Console.ReadLine();
                                            Console.WriteLine("Enter Your PhoneNumber");
                                            UserUpdate.PhoneNumber = Console.ReadLine();
                                            Console.WriteLine("To'lov ma'lumotlaringizni Kiriting");
                                            Console.WriteLine("1 => Payme");
                                            Console.WriteLine("2 => Paypal");
                                            Console.WriteLine("3 => Click");
                                            Console.WriteLine("4 => Oson");
                                            UserUpdate.PaymentMethod = (Method)Enum.Parse(typeof(Method), Console.ReadLine());
                                            Console.WriteLine("Hisobingizdagi Balansni kiritng");
                                            UserUpdate.Balance = decimal.Parse(Console.ReadLine());
                                            await ServiceUser.UpdateAsync(UserUpdate);
                                            break;
                                        case 6:
                                            var UserServices = new UserService();
                                            var Profiles = (await UserServices.GetAllAsync()).FirstOrDefault(e => e.Email == Auth.Email && e.Password == Auth.Password);
                                            Console.WriteLine("Your FirstName " + Profiles.FirstName);
                                            Console.WriteLine("Your LastName " + Profiles.LastName);
                                            Console.WriteLine("Your Email " + Profiles.Email);
                                            Console.WriteLine("Your Password " + Profiles.Password);
                                            Console.WriteLine("Your Balance " + Profiles.Balance);
                                            break;
                                        case 7:
                                            userLoop = false;
                                            break;
                                    }
                                }
                                break;

                            case AuthResult.ArtistAuthenticated:
                                var ArtistLoop = true;
                                while(ArtistLoop)
                                {
                                    Console.WriteLine("1 => Add Artwork");
                                    Console.WriteLine("2 => My Artworks");
                                    Console.WriteLine("3 => Sold Artworks");
                                    Console.WriteLine("4 => See My Balance");
                                    Console.WriteLine("5 => See My Profile");
                                    Console.WriteLine("6 => Update My Profile");
                                    Console.WriteLine("7 => Log Out");
                                    var num5 = int.Parse(Console.ReadLine());
                                    ArtistService artistService = new ArtistService();
                                    var ArtistProfile = (await artistService.GetAllAsync()).FirstOrDefault(e => e.Email == Auth.Email && e.Password == Auth.Password);
                                    switch(num5)
                                    {
                                        case 1:
                                            ArtworkService ServiceForArtwork = new ArtworkService();
                                            ArtworkForCreationDto artDto = new ArtworkForCreationDto();
                                            artDto.ArtistId = ArtistProfile.Id;
                                            Console.WriteLine("Enter The Artwork Title");
                                            artDto.Title = Console.ReadLine();

                                            Console.WriteLine("Enter The Artwork Description");
                                            artDto.Desciption = Console.ReadLine();

                                            Console.WriteLine("Enter The Artwork Category");
                                            Console.WriteLine("1 => Grafitti");
                                            Console.WriteLine("2 => StreetArt");
                                            Console.WriteLine("3 => AbstractExpressionism");
                                            Console.WriteLine("4 => Calligraphy");
                                            Console.WriteLine("5 => Mosaic");
                                            artDto.Category = (ArtCategory)Enum.Parse(typeof(ArtCategory), Console.ReadLine());

                                            Console.WriteLine("Enter The Artwork Price");
                                            artDto.Price = decimal.Parse(Console.ReadLine());


                                            await ServiceForArtwork.CreateAsync(artDto);

                                            break;
                                        case 2:
                                            var MyArtworks = AllArtWorks.Where(e => e.ArtistId == ArtistProfile.Id);
                                            foreach (var art in MyArtworks)
                                            {
                                                Console.WriteLine("_____________________________________");
                                                Console.WriteLine("Artwork Id: " + art.Id);
                                                Console.WriteLine("Artwork Title: " + art.Title);
                                                Console.WriteLine("Artwork Category: " + art.Category);
                                                Console.WriteLine("Artwork Descripion: " + art.Desciption);
                                                Console.WriteLine("Artwork Price: " + art.Price);
                                                Console.WriteLine("_____________________________________");
                                            }
                                            break;
                                        case 3:
                                            PurchaseService ServiceForPurchase = new PurchaseService();
                                            var SoldArtworks = await ServiceForPurchase.GetMyAllPurchasedArtsAsync(ArtistProfile.Id);
                                            foreach (var art in SoldArtworks)
                                            {
                                                    Console.WriteLine("_____________________________________");
                                                    Console.WriteLine("Artwork Id: " + art.Id);
                                                    Console.WriteLine("Artwork Title: " + art.Title);
                                                    Console.WriteLine("Artwork Category: " + art.Category);
                                                    Console.WriteLine("Artwork Descripion: " + art.Desciption);
                                                    Console.WriteLine("Artwork Price: " + art.Customer);
                                                    Console.WriteLine("Artwork Price: " + art.Price);
                                                    Console.WriteLine("_____________________________________");
                                            }
                                            break;
                                    }
                                }
                                break;
                        }
                        break;
                }
            }
        }
    }
}
