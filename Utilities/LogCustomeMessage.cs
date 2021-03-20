namespace Utilities
{
    public static class LogCustomeMessage
    {
        public static string ReadMessage(string project, string currentClass, string method, string description)
        {
            var message = $"Project:{project}, Class:{currentClass}, " +
                          $"Description:{description},  Method:{method}";
            return message;
        }
    }
}