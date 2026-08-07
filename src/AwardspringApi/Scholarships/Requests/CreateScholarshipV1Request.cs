using AwardspringApi.Core;
using global::System.Text.Json.Serialization;

namespace AwardspringApi;

[Serializable]
public record CreateScholarshipV1Request
{
    /// <summary>
    /// Human-readable name of the scholarship. Required, non-whitespace. Example: `"Spring 2026 STEM Award"`.
    /// </summary>
    [JsonPropertyName("scholarship_name")]
    public string? ScholarshipName { get; set; }

    /// <summary>
    /// Optional external fund identifier (matches a `Fund.FundIdName` in the tenant's funds
    /// directory). When Funds Management is enabled and the supplied ID does not match an existing
    /// fund, a new fund row is created automatically. When it matches, the scholarship is linked to
    /// that fund. Example: `"GEN-2026"`.
    /// </summary>
    [JsonPropertyName("fund_id")]
    public string? FundId { get; set; }

    /// <summary>
    /// Free-form description of the scholarship. Required, non-whitespace. Shown to applicants in
    /// the scholarship details panel. Example: `"Award for incoming STEM majors with financial need."`.
    /// </summary>
    [JsonPropertyName("scholarship_description")]
    public string? ScholarshipDescription { get; set; }

    /// <summary>
    /// Whether this is a Special Funds scholarship (a tenant-controlled cap on how many of these
    /// can exist per award cycle). Defaults to `false`. Cannot be combined with
    /// IsInstitutionalAwardScholarship — a request with both set to `true` is
    /// rejected with a `validation_failed` error.
    /// </summary>
    [JsonPropertyName("is_special_funds")]
    public bool? IsSpecialFunds { get; set; }

    /// <summary>
    /// AwardSpring award-cycle identifier this scholarship belongs to. Required. Example: `12`.
    /// </summary>
    [JsonPropertyName("award_cycle_id")]
    public required int AwardCycleId { get; set; }

    /// <summary>
    /// ISO 8601 datetime when applicants can begin applying. Example: `"2026-08-01T00:00:00"`.
    /// Interpreted in the tenant's configured time zone.
    /// </summary>
    [JsonPropertyName("application_start_date")]
    public string? ApplicationStartDate { get; set; }

    /// <summary>
    /// ISO 8601 datetime when applications close. The persistence layer normalizes this to the end
    /// of the chosen day. Example: `"2026-10-15T23:59:59"`. Must be after
    /// ApplicationStartDate and within the parent award cycle's date range.
    /// </summary>
    [JsonPropertyName("application_end_date")]
    public string? ApplicationEndDate { get; set; }

    /// <summary>
    /// ISO 8601 date of the first disbursement to awarded students. Required — the admin UI
    /// requires it on every scholarship, and this endpoint enforces the same rule. Defaults are
    /// not applied server-side; send the institution's intended first payment date. Example:
    /// `"2027-01-15"`.
    /// </summary>
    [JsonPropertyName("disbursement_date")]
    public string? DisbursementDate { get; set; }

    /// <summary>
    /// Optional label for the first disbursement's academic term, shown alongside the
    /// disbursement date. Maximum 50 characters. Example: `"Spring 2027"`.
    /// </summary>
    [JsonPropertyName("first_disbursement_term_name")]
    public string? FirstDisbursementTermName { get; set; }

    /// <summary>
    /// Optional total number of recipients to award. Combined with TotalScholarshipValue
    /// to derive a per-award amount. Must be a positive integer (1 to 999,999) when supplied. Example: `10`.
    /// </summary>
    [JsonPropertyName("total_awards_number")]
    public int? TotalAwardsNumber { get; set; }

    /// <summary>
    /// Optional total dollar value of the scholarship across all recipients. Combined with
    /// TotalAwardsNumber to derive a per-award amount. Must be non-negative when
    /// supplied. Example: `50000.00`.
    /// </summary>
    [JsonPropertyName("total_scholarship_value")]
    public double? TotalScholarshipValue { get; set; }

    /// <summary>
    /// Optional number of payments each recipient receives. Must be 1 or greater when supplied.
    /// Example: `2`.
    /// </summary>
    [JsonPropertyName("payments_per_award")]
    public int? PaymentsPerAward { get; set; }

    /// <summary>
    /// Optional AwardSpring department ID the scholarship is owned by. Used for Department Admin
    /// scoping. Example: `3`.
    /// </summary>
    [JsonPropertyName("department_id")]
    public int? DepartmentId { get; set; }

    /// <summary>
    /// Optional list of donor or donor-organization user IDs associated with the scholarship.
    /// Example: `[101, 102]`.
    /// </summary>
    [JsonPropertyName("donor_ids")]
    public IEnumerable<int>? DonorIds { get; set; }

    /// <summary>
    /// Whether the scholarship is deactivated on create (rare — typically left `false`).
    /// Example: `false`.
    /// </summary>
    [JsonPropertyName("is_deactivate_scholarship")]
    public bool? IsDeactivateScholarship { get; set; }

    /// <summary>
    /// Whether this is an Institutional Award scholarship (recipients selected by the institution
    /// rather than through a public application flow). Cannot be combined with
    /// IsSpecialFunds — a request with both set to `true` is rejected with a
    /// `validation_failed` error. Example: `false`.
    /// </summary>
    [JsonPropertyName("is_institutional_award_scholarship")]
    public bool? IsInstitutionalAwardScholarship { get; set; }

    /// <summary>
    /// Optional internal notes for admin staff. Not shown to applicants. Example:
    /// `"Cycle 2026 STEM partnership with ACME Corp."`.
    /// </summary>
    [JsonPropertyName("internal_notes")]
    public string? InternalNotes { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
