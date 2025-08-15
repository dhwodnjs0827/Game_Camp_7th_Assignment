public static class TimeFormatUtility
{
    /// <summary>
    /// float 값(초)을 MM:SS 형식의 문자열로 변환
    /// </summary>
    /// <param name="seconds">초 단위의 시간</param>
    /// <returns>MM:SS 형식의 문자열</returns>
    public static string ToMinuteSecond(float seconds)
    {
        int totalSeconds = (int)seconds;
        
        int minutes = totalSeconds / 60;
        int remainingSeconds = totalSeconds % 60;
        
        return $"{minutes:D2}:{remainingSeconds:D2}";
    }
}