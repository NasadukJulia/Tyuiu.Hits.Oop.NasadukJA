using System;

namespace EliaRestaurant.Models
{
    // Класс, описывающий бронирование столика
    public class Booking
    {
        // Номер бронирования
        public int Id { get; set; }

        // Забронированный столик
        public RestaurantTable Table { get; set; }

        // Клиент, который забронировал столик
        public Client Client { get; set; }

        // Дата посещения ресторана
        public DateTime Date { get; set; }

        // Время посещения ресторана
        public string Time { get; set; }

        // Количество гостей
        public int Guests { get; set; }

        // Информация о том, отменена ли бронь
        public bool IsCancelled { get; set; }

        // Конструктор для создания бронирования
        public Booking(int id, RestaurantTable table,
            Client client, DateTime date, string time, int guests)
        {
            Id = id;
            Table = table;
            Client = client;
            Date = date;
            Time = time;
            Guests = guests;

            // При создании бронирование является активным
            IsCancelled = false;
        }

        // Метод для получения статуса бронирования
        public string GetStatus()
        {
            if (IsCancelled == true)
            {
                return "Отменена";
            }
            else
            {
                return "Активна";
            }
        }
    }
}