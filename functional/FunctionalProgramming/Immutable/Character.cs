namespace FunctionalProgramming.Immutable {
    public class Character {
        public Character(int health) {
            Health = health;
        }

        public int Health { get; } = 100;

        public Character Hit(int damage) {
            return new Character(Health - damage);
        }
    }
}