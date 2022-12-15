namespace TaskSehirTeknolojileri_Service.Utilities
{
    public static class Messages
    {
        public static string AuthorizationDenied = "Yetkiniz yok";

        public static class Customer
        {
            public static string Count(int count)
            {
                if (count < 0) return "Müşteri yoktur.";
                return $"{count} tane Müşteri sahibiz.";
            }
            public static string NotFound(bool isPlural)
            {
                if (isPlural) return "Hiç bir Müşteri bulunamadı";
                return "Böyle bir Müşteri bulunamadı";
            }
            public static string Add(string customerName)
            {
                return $"{customerName} adlı Müşteri başarıyla eklenmiştir.";
            }
            public static string NotAdd(string customerName)
            {
                return $"{customerName} adlı Müşteri eklenmemiştir.";
            }
            public static string Update(string customerName)
            {
                return $"{customerName} adlı Müşteri başarıyla güncellenmiştir.";
            }
            public static string Delete(string customerName)
            {
                return $"{customerName} adlı Müşteri silinmiştir.";
            }
            public static string HardDelete(string customerName)
            {
                return $"{customerName} adlı Müşteri başarıyla veritabanından silinmiştir";
            }
            public static string NonDelete(string customerName)
            {
                return $"{customerName} adlı müşteri silinmemiştir.";
            }
        }
        public static class Product
        {
            public static string Count(int count)
            {
                if (count < 0) return "Ürün stokumuz bitmiştir";
                return $"{count} tane ürün stokıumuz vardır.";
            }
            public static string NotFound(bool isPlural)
            {
                if (isPlural) return "Hiç bir ürün bulunamadı";
                return "Böyle bir ürün bulunamadı";
            }
            public static string Add(string productName)
            {
                return $"{productName} adlı ürün başarıyla eklenmiştir.";
            }
            public static string NotAdd(string productName)
            {
                return $"{productName} adlı ürün eklenmemiştir.";
            }
            public static string Update(string productName)
            {
                return $"{productName} adlı ürün başarıyla güncellenmiştir.";
            }
            public static string Delete(string productName)
            {
                return $"{productName} adlı ürün silinmiştir.";
            }
            public static string NonDelete(string productName)
            {
                return $"{productName} adlı ürün silinmemiştir.";
            }
            public static string HardDelete(string productName)
            {
                return $"{productName} adlı ürün başarıyla veritabanından silinmiştir";
            }
        }
        public static class Category
        {
            public static string Count(int count)
            {
                if (count < 0) return "Kategori yoktur.";
                return $"{count} tane Kategori sahibiz.";
            }
            public static string NotFound(bool isPlural)
            {
                if (isPlural) return "Hiç bir Kategori bulunamadı";
                return "Böyle bir Kategori bulunamadı";
            }
            public static string Add(string categoryName)
            {
                return $"{categoryName} adlı Kategori başarıyla eklenmiştir.";
            }
            public static string NotAdd(string categoryName)
            {
                return $"{categoryName} adlı Kategori eklenmemiştir.";
            }
            public static string Update(string categoryName)
            {
                return $"{categoryName} adlı Kategori başarıyla güncellenmiştir.";
            }
            public static string Delete(string categoryName)
            {
                return $"{categoryName} adlı Kategori silinmiştir.";
            }
            public static string HardDelete(string categoryName)
            {
                return $"{categoryName} adlı Kategori başarıyla veritabanından silinmiştir";
            }
        }

    }
}
