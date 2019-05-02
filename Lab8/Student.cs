namespace Lab8
{
    internal class Student
    {
        public string Name { get; }
        public string FavoriteFood { get; }
        public string HomeTown { get; }

        public Student(string Name, string FavoriteFood, string HomeTown)
        {
            this.Name = Name;
            this.FavoriteFood = FavoriteFood;
            this.HomeTown = HomeTown;
        }
    }
}