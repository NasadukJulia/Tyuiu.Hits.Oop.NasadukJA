using System;
using System.Collections.Generic;
using EliaRestaurant.Models;

namespace EliaRestaurant.Services
{
    // Класс для управления бронированиями столиков
    public class BookingService
    {
        // Список всех столиков ресторана
        public List<RestaurantTable> Tables { get; set; }

        // Список всех бронирований
        public List<Booking> Bookings { get; set; }

        // Конструктор класса
        public BookingService()
        {
            // Создаём пустые списки
            Tables = new List<RestaurantTable>();
            Bookings = new List<Booking>();

            // Добавляем шесть столиков разной вместимости
            Tables.Add(new RestaurantTable(1, 2));
            Tables.Add(new RestaurantTable(2, 2));
            Tables.Add(new RestaurantTable(3, 4));
            Tables.Add(new RestaurantTable(4, 4));
            Tables.Add(new RestaurantTable(5, 6));
            Tables.Add(new RestaurantTable(6, 8));
        }

        // Метод для проверки доступности столика
        public bool IsAvailable(int tableId, DateTime date, string time)
        {
            // Перебираем все существующие бронирования
            foreach (Booking booking in Bookings)
            {
                // Проверяем номер столика, дату, время
                // и не отменено ли бронирование
                if (booking.Table.Id == tableId &&
                    booking.Date.Date == date.Date &&
                    booking.Time == time &&
                    booking.IsCancelled == false)
                {
                    // Столик уже занят
                    return false;
                }
            }

            // Если подходящей активной брони нет,
            // значит столик свободен
            return true;
        }

        // Метод для создания нового бронирования
        public string AddBooking(RestaurantTable table,
            string name, string phone, DateTime date,
            string time, int guests)
        {
            // Проверяем, заполнены ли данные клиента
            if (string.IsNullOrWhiteSpace(name) ||
                string.IsNullOrWhiteSpace(phone))
            {
                return "Введите имя и номер телефона!";
            }

            // Проверяем, не прошла ли выбранная дата
            if (date.Date < DateTime.Today)
            {
                return "Нельзя выбрать прошедшую дату!";
            }

            // Проверяем время бронирования
            if (time != "12:00" && time != "14:00" &&
                time != "16:00" && time != "18:00" &&
                time != "20:00")
            {
                return "Выберите время посещения!";
            }

            // Проверяем, не прошло ли выбранное время
            if (date.Date == DateTime.Today &&
                TimeSpan.Parse(time) <= DateTime.Now.TimeOfDay)
            {
                return "Выбранное время уже прошло!";
            }

            // Проверяем количество гостей
            if (guests <= 0)
            {
                return "Укажите количество гостей!";
            }

            // Проверяем вместимость столика
            if (guests > table.Seats)
            {
                return "За этим столиком недостаточно мест!";
            }

            // Проверяем, свободен ли столик
            if (IsAvailable(table.Id, date, time) == false)
            {
                return "Этот столик уже забронирован!";
            }

            // Создаём объект клиента
            Client client = new Client(name, phone);

            // Определяем номер нового бронирования
            int id = Bookings.Count + 1;

            // Создаём объект бронирования
            Booking booking = new Booking(
                id, table, client, date, time, guests);

            // Добавляем бронирование в список
            Bookings.Add(booking);

            // Возвращаем сообщение об успешной брони
            return "Столик успешно забронирован!";
        }

        // Метод для отмены бронирования
        public string CancelBooking(int id)
        {
            // Ищем бронирование по его номеру
            foreach (Booking booking in Bookings)
            {
                if (booking.Id == id &&
                    booking.IsCancelled == false)
                {
                    // Изменяем статус бронирования
                    booking.IsCancelled = true;

                    return "Бронирование отменено!";
                }
            }

            // Если активная бронь не найдена
            return "Активное бронирование не найдено!";
        }
    }
}