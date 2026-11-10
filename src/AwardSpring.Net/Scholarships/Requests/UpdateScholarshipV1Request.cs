using AwardSpring.Net.Core;
using global::System.Text.Json.Serialization;

namespace AwardSpring.Net;

[Serializable]
public record UpdateScholarshipV1Request
{
    /// <summary>
    /// The scholarship's stored ID.
    /// </summary>
    [JsonIgnore]
    public required string ScholarshipId { get; set; }

    /// <summary>
    /// The scholarship's new name. It cannot be blank, and no other scholarship in the same award cycle may have it.
    /// Example: `"Smith Family Nursing Scholarship"`.
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// The new day the application window opens. A date without a time (`"2026-09-01"`) is that calendar day
    /// in the institution's time zone, and the scholarship keeps the time of day it opens at now. A date and time
    /// with an offset (`"2026-09-01T08:00:00-04:00"`) is used exactly as sent. It cannot be cleared, and it
    /// must fall before the close date and inside the award cycle, as on the scholarship's Details tab.
    /// </summary>
    [JsonPropertyName("application_start_date")]
    public string? ApplicationStartDate { get; set; }

    /// <summary>
    /// The new day the application window closes. A date without a time (`"2026-12-01"`) is that calendar day
    /// in the institution's time zone, and the scholarship keeps the time of day it closes at now, so a
    /// scholarship that closes at the end of the day closes at the end of the new day. A date and time with an
    /// offset (`"2026-12-01T17:00:00-05:00"`) is used exactly as sent. It cannot be cleared, and it must fall
    /// after the open date and inside the award cycle, as on the scholarship's Details tab.
    /// </summary>
    [JsonPropertyName("application_end_date")]
    public string? ApplicationEndDate { get; set; }

    /// <summary>
    /// The stored ID of the department the scholarship moves to. An empty string removes its department.
    /// Example: `"4MZ8RT2QX"`.
    /// </summary>
    [JsonPropertyName("department_id")]
    public string? DepartmentId { get; set; }

    /// <summary>
    /// The fund code the scholarship is paid from, as the create call takes it, at most 128 characters. A code the
    /// institution does not have yet adds that fund, as the Details tab does. An empty string removes the fund.
    /// Example: `"NURS-2026"`.
    /// </summary>
    [JsonPropertyName("fund_id")]
    public string? FundId { get; set; }

    /// <summary>
    /// The stored IDs of donors to link to the scholarship. Each must be a donor or organization at the institution
    /// that is not archived and not already linked. Example: `["9QW3ZK7HD"]`.
    /// </summary>
    [JsonPropertyName("add_donor_ids")]
    public IEnumerable<string>? AddDonorIds { get; set; }

    /// <summary>
    /// The stored IDs of donors to unlink from the scholarship. Each must be linked to it now, and none may also be
    /// in `add_donor_ids`. Example: `["2HX6PC4MT"]`.
    /// </summary>
    [JsonPropertyName("remove_donor_ids")]
    public IEnumerable<string>? RemoveDonorIds { get; set; }

    /// <summary>
    /// The scholarship's new description, replacing the whole description students see. It cannot be blank.
    /// </summary>
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("award_notification")]
    public UpdateScholarshipAwardNotificationV1Request? AwardNotification { get; set; }

    /// <summary>
    /// New values for custom fields, each named by its stored ID; a field not listed keeps its value. The same rules
    /// as the Details tab apply: a choice field takes only its active choices, and a value outside them is refused
    /// naming the field. Each field may be listed once.
    /// Example: `[{"id": "3KD8WQ2MZ", "value": "Merit"}, {"id": "7RT4HX9NC", "values": ["Nursing", "Biology"]}]`.
    /// </summary>
    [JsonPropertyName("custom_fields")]
    public IEnumerable<UpdateScholarshipCustomFieldV1Request>? CustomFields { get; set; }

    /// <summary>
    /// Qualification rules to remove, each from one group. Removals are applied before additions. A removal that
    /// matches no rule is refused. Group numbers are the scholarship's `qualification_groups` as last read; a
    /// group left with no rules is dropped at the end and the groups after it move up. Refused once the application
    /// window has closed. Example: `[{"question_id": "4MZ8RT2QX", "group": 1}]`.
    /// </summary>
    [JsonPropertyName("remove_qualifications")]
    public IEnumerable<RemoveScholarshipQualificationV1Request>? RemoveQualifications { get; set; }

    /// <summary>
    /// Qualification rules to add, applied in list order after the removals. To change a rule, remove it and add
    /// the new one in the same request. A question can back at most one rule per group; a scholarship can have at
    /// most 10 groups, or 1 on AwardSpring Now. Refused once the application window has closed. Students are
    /// re-checked in the background after the save, so their qualified state changes shortly after the call
    /// returns, not at once.
    /// Example: `[{"question_id": "4MZ8RT2QX", "title": "GPA 3.2 or higher", "comparison": "at_least", "value": 3.2}]`.
    /// </summary>
    [JsonPropertyName("add_qualifications")]
    public IEnumerable<AddScholarshipQualificationV1Request>? AddQualifications { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
