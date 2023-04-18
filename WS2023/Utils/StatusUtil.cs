namespace WS2023.Utils
{
    public class StatusUtil
    {
        public static string statusToString(int status)
        {
            switch (status)
            {
                case 0:
                    return "В процессе";
                case 1:
                    return "Успешно";
                default:
                    return "Отклонено";
            }
        }
    }
}
