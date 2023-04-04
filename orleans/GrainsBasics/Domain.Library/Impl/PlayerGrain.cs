using Domain.Library.Interfaces;
using Orleans;

namespace Domain.Library.Impl
{
    public class PlayerGrain : Grain, IPlayerGrain
    {
        private IGameGrain? currentGame;

        public Task<IGameGrain> GetCurrentGame()
        {
#pragma warning disable CS8619 // Nullability of reference types in value doesn't match target type.
            return Task.FromResult(currentGame);
#pragma warning restore CS8619 // Nullability of reference types in value doesn't match target type.
        }

        public Task JoinGame(IGameGrain game)
        {
            currentGame = game;

            Console.WriteLine(
                "Player {0} joined game {1}",
                this.GetPrimaryKey(),
                game.GetPrimaryKey());

            return Task.CompletedTask;
        }

        public Task LeaveGame(IGameGrain game)
        {
            currentGame = null;
            Console.WriteLine(
                "Player {0} left game {1}",
                this.GetPrimaryKey(),
                game.GetPrimaryKey());

            return Task.CompletedTask;
        }
    }
}
