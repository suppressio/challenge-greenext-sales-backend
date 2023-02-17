using Api_SalesTaxesTest.Models;
using System.Text.Json;

namespace Api_SalesTaxesTest.Controllers
{
    public static class ShoppingCartSessionStorage
    {

        public static ShoppingCart Get(this ISession session, string key)
        {
            var value = session.GetString(key);
            if (value != null)
            {
                ShoppingCart? sc = JsonSerializer.Deserialize<ShoppingCart>(value);

                if (sc != null)
                    return sc;
            }

            return new ShoppingCart();
        }
        public static void Set(this ISession session, string key, ShoppingCart update)
        {
            session.SetString(key, JsonSerializer.Serialize(update));
        }

        public static int GetCounter(this ISession session, string key)
        {
            var value = session.GetInt32("counter_" + key);
            return value != null ? (int)value : 1;
        }

        public static void SetCounter(this ISession session, string key, int update)
        {
            session.SetInt32("counter_" + key, update);
        }
    }
}
