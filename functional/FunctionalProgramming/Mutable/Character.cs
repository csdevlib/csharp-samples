namespace FunctionalProgramming.Mutable {
    public class Character {
        public int Health { get; private set; } = 100;

        public Character(int health) {
            Health = health;
        }

        public Character Hit(int damage) {
            return new Character(Health - damage);
        }
    }
}