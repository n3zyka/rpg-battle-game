namespace RPG_Battle
{
    public class Quest
    {
        public string Name { get; private set; }
        public bool IsCompleted { get; private set; }

        public Quest(string name)
        {
            Name = name;
            IsCompleted = false;
        }

        public void Complete()
        {
            IsCompleted = true;
        }
    }
}
