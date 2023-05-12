using Microsoft.AspNetCore.Http;
using System.Security.Cryptography;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace PigApp.Models
{
    public static class SessionExtentions
    {
        public static void SetObject<T>(this ISession session, string key, T value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        public static T GetObject<T>(this ISession session, string key)
        {
            var jsonString = session.GetString(key);
            if (string.IsNullOrEmpty(jsonString))
                return default(T);
            else
                return JsonConvert.DeserializeObject<T>(jsonString);

        }
    }

    public class GameSession
    {
        private const string GameKey = "pigGame";

        private ISession session;
        public GameSession(ISession sess) => session = sess;

        public Game GetGame() => session.GetObject<Game>(GameKey) ?? new Game();

        public void SetGame(Game game) => session.SetObject(GameKey, game);
    }
    
}
