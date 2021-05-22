namespace SeleniumPractice.SauceDemo
{
    static class WebUrl
    {
        public static string BaseUrl { get; } = "https://www.saucedemo.com";
        public static string LoginPage { get; } = BaseUrl;
        public static string InventoryPage { get; } = BaseUrl + "/inventory.html";
        public static string InventoryItemPage { get; } = BaseUrl + "/inventory-item.html?id={item_id}";
        public static string CartPage { get; } = BaseUrl + "/cart.html";
    }
}
