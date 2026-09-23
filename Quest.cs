namespace RPG_Battle
{
    public class Quest
    {
        public string Name { get; set; }
        public bool IsCompleted { get; set; }

        public Quest(string name)
        {
            Name = name;
            IsCompleted = false;
        }
    }
}
