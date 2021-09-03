using System.IO;
using System.Text;
using Microsoft.AspNetCore.Http;
using Store.Web.Models;

namespace Store.Web
{
    public static class SessionExtensions
    {
        private const string Key = "Cart";
        public static void SetCart(this ISession session, Cart valueToSave)
        {
            using var stream = new MemoryStream();
            using var writer = new BinaryWriter(stream, Encoding.UTF8, true);

            writer.Write(valueToSave.Price);
            writer.Write(valueToSave.Items.Count);
            foreach (var item in valueToSave.Items)
            {
                writer.Write(item.Key);
                writer.Write(item.Value);
            }
            session.Set(Key, stream.ToArray());
        }
        public static Cart? GetCart(this ISession session)
        {
            var cartByte = session.Get(Key);
            if (cartByte == null)
            {
                return null;
            }

            using var stream = new MemoryStream(cartByte);
            using var reader = new BinaryReader(stream, Encoding.UTF8, true);

            Cart result = new()
            {
                Price = reader.ReadDecimal()
            };
            var count = reader.ReadInt32();
            for (var i = 0; i < count; i++)
            {
                var key = reader.ReadInt32();
                var value = reader.ReadInt32();
                result.Items[key] = value;
            }

            return result;
        }
    }
}