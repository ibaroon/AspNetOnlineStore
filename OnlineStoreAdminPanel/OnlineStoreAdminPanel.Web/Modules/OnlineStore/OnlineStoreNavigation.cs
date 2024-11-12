using Serenity.Navigation;
using MyPages = OnlineStoreAdminPanel.OnlineStore.Pages;

[assembly: NavigationLink(int.MaxValue, "OnlineStore/Cart", typeof(MyPages.CartPage), icon: null)]
[assembly: NavigationLink(int.MaxValue, "OnlineStore/Catigory", typeof(MyPages.CatigoryPage), icon: null)]
[assembly: NavigationLink(int.MaxValue, "OnlineStore/Product", typeof(MyPages.ProductPage), icon: null)]
[assembly: NavigationLink(int.MaxValue, "OnlineStore/Product Images", typeof(MyPages.ProductImagesPage), icon: null)]
[assembly: NavigationLink(int.MaxValue, "OnlineStore/Review", typeof(MyPages.ReviewPage), icon: null)]