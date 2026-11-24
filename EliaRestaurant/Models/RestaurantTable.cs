namespace EliaRestaurant.Models
{
    // Класс, описывающий столик в ресторане
    public class RestaurantTable
    {
        // Номер столика
        public int Id { get; set; }

        // Количество посадочных мест
        public int Seats { get; set; }

        // Конструктор для создания столика
        public RestaurantTable(int id, int seats)
        {
            Id = id;
            Seats = seats;
        }
    }
}