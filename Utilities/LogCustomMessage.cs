namespace Utilities
{
    public static class LogCustomMessage
    {
        public static string WriteMessage(string project, string currentClass, string method, string description)
        {
            var message = $"Project:{project}, Class:{currentClass}, " +
                          $"Description:{description},  Method:{method}";
            return message;
        }
    }
}