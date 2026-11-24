namespace EliaRestaurant.Models
{
    // Класс, описывающий клиента ресторана
    public class Client
    {
        // Имя клиента
        public string Name { get; set; }

        // Номер телефона клиента
        public string Phone { get; set; }

        // Конструктор для создания клиента
        public Client(string name, string phone)
        {
            Name = name;
            Phone = phone;
        }
    }
}