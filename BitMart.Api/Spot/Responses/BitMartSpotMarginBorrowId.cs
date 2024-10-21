namespace BitMart.Api.Spot;

internal record BitMartSpotMarginBorrowId
{
    /// <summary>
    /// Borrow Id
    /// </summary>
    [JsonProperty("borrow_id")]
    public long BorrowId { get; set; }
}
