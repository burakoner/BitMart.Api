namespace BitMart.Api.Spot;

/// <summary>
/// Kline interval
/// </summary>
public enum BitMartSpotKlineInterval
{
    /// <summary>
    /// One minute
    /// </summary>
    [Map("1", "1m")]
    OneMinute = 60,

    /// <summary>
    /// Three minutes
    /// </summary>
    [Map("3")]
    ThreeMinutes = 180,

    /// <summary>
    /// Five minutes
    /// </summary>
    [Map("5", "5m")]
    FiveMinutes = 300,

    /// <summary>
    /// Fifteen minutes
    /// </summary>
    [Map("15", "15m")]
    FifteenMinutes = 900,

    /// <summary>
    /// Thirty minutes
    /// </summary>
    [Map("30", "30m")]
    ThirtyMinutes = 1800,

    /// <summary>
    /// Fourty five minutes
    /// </summary>
    [Map("45")]
    FourtyFiveMinutes = 2700,

    /// <summary>
    /// One hour
    /// </summary>
    [Map("60", "1H")]
    OneHour = 3600,

    /// <summary>
    /// Two hours
    /// </summary>
    [Map("120", "2H")]
    TwoHours = 7200,

    /// <summary>
    /// Three hours
    /// </summary>
    [Map("180")]
    ThreeHours = 10800,

    /// <summary>
    /// Four hours
    /// </summary>
    [Map("240", "4H")]
    FourHours = 14400,

    /// <summary>
    /// One day
    /// </summary>
    [Map("1440", "1D")]
    OneDay = 86400,

    /// <summary>
    /// One week
    /// </summary>
    [Map("10080", "1W")]
    OneWeek = 604800,

    /// <summary>
    /// One month
    /// </summary>
    [Map("43200", "1M")]
    OneMonth = 2592000
}
