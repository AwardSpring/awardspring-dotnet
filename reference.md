# Reference
## Award Cycles
<details><summary><code>client.AwardCycles.<a href="/src/AwardSpring.Net/AwardCycles/AwardCyclesClient.cs">ListAsync</a>(ListAwardCyclesRequest { ... }) -> WithRawResponseTask&lt;AwardCycleV1ListResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Returns the award cycles belonging to the institution your API key is issued for, in the list
envelope (`object: "list"`, `has_more`, `next_cursor`, `previous_cursor`,
`data`). Page forward by passing the returned `next_cursor` as `starting_after`;
the last page has `next_cursor: null`. `limit` defaults to 25 and is capped at 100.
Results are ordered by award-cycle id ascending. Filter with `?q=` (case-insensitive
substring match on the award-cycle name).
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.AwardCycles.ListAsync(new ListAwardCyclesRequest());
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `ListAwardCyclesRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.AwardCycles.<a href="/src/AwardSpring.Net/AwardCycles/AwardCyclesClient.cs">GetCurrentAsync</a>() -> WithRawResponseTask&lt;AwardCycleV1&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Returns a single AwardCycleV1 resource. The lookup prefers the cycle the
institution has marked current; when none is marked current it falls back to the cycle
marked next. When neither exists the endpoint returns `404 award_cycle_not_found` in the
structured v1 error shape — in that case list all cycles via `GET /api/v1/award-cycles`
and ask the user which one to use.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.AwardCycles.GetCurrentAsync();
```
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Donor Activities
<details><summary><code>client.DonorActivities.<a href="/src/AwardSpring.Net/DonorActivities/DonorActivitiesClient.cs">ListAsync</a>(ListDonorActivitiesRequest { ... }) -> WithRawResponseTask&lt;DonorActivityV1ListResponse&gt;</code></summary>
<dl>
<dd>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.DonorActivities.ListAsync(new ListDonorActivitiesRequest { DonorId = 1 });
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `ListDonorActivitiesRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.DonorActivities.<a href="/src/AwardSpring.Net/DonorActivities/DonorActivitiesClient.cs">CreateAsync</a>(CreateDonorActivityV1Request { ... }) -> WithRawResponseTask&lt;CreateDonorActivityV1Response&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Records that an interaction with a donor took place — a call you just finished, a meeting, an
email, a note, or a verbal pledge. Errors come back with a stable `code`, a readable
`message`, and per-field `details`, so a caller can tell what to correct.


Supported activity types: `LoggedEmail`, `LoggedPhone`, `LoggedMeeting`, `LoggedNote`,
`LoggedPledge`. Gifts are recorded through the Gifts endpoints instead.


A typical use is working through a call list and logging each conversation as it ends, with the
summary and any follow-up owner attached.


Set `dry_run=true` (query param or `Dry-Run: true` header) to validate without persisting.

<b>Idempotency:</b> the request supports an optional `Idempotency-Key` header (any printable-ASCII
string, 1–255 chars — UUIDs work well). When supplied, the same key + same request body within 24 hours
returns the original response verbatim without creating a duplicate activity. The same key with a
different body returns `422 idempotency_key_request_mismatch`; a concurrent retry while the first
call is still executing returns `409 idempotency_key_in_flight`. Only 2xx responses are cached —
4xx/5xx leave the key available for retry with a corrected payload.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.DonorActivities.CreateAsync(new CreateDonorActivityV1Request { DonorId = 1 });
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `CreateDonorActivityV1Request` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.DonorActivities.<a href="/src/AwardSpring.Net/DonorActivities/DonorActivitiesClient.cs">GetAsync</a>(GetDonorActivitiesRequest { ... }) -> WithRawResponseTask&lt;DonorActivityV1&gt;</code></summary>
<dl>
<dd>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.DonorActivities.GetAsync(
    new GetDonorActivitiesRequest { DonorId = 1, ActivityId = 1 }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `GetDonorActivitiesRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Donors
<details><summary><code>client.Donors.<a href="/src/AwardSpring.Net/Donors/DonorsClient.cs">ListAsync</a>(ListDonorsRequest { ... }) -> WithRawResponseTask&lt;DonorListItemV1ListResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Returns one page at a time. Search with `q`: it splits on spaces and matches each
term against first name, last name, email, or organization, so `jane smith` finds
donors matching both terms.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Donors.ListAsync(new ListDonorsRequest());
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `ListDonorsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Donors.<a href="/src/AwardSpring.Net/Donors/DonorsClient.cs">CreateAsync</a>(CreateDonorV1Request { ... }) -> WithRawResponseTask&lt;DonorV1&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Creates either an individual or an organization, depending on `role`. Send
`dry_run` to validate the request without saving it, and an `Idempotency-Key`
header so a retry cannot create the same donor twice.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Donors.CreateAsync(new CreateDonorV1Request());
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `CreateDonorV1Request` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Donors.<a href="/src/AwardSpring.Net/Donors/DonorsClient.cs">GetAsync</a>(GetDonorsRequest { ... }) -> WithRawResponseTask&lt;DonorDetailV1&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Includes giving totals for the donor's lifetime and the current year, their most recent
gift, and their notes. Returns `404 donor_not_found` if no such donor belongs to
this institution.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Donors.GetAsync(new GetDonorsRequest { Id = 1 });
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `GetDonorsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Donors.<a href="/src/AwardSpring.Net/Donors/DonorsClient.cs">UpdateAsync</a>(UpdateDonorV1Request { ... }) -> WithRawResponseTask&lt;DonorV1&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Only the fields present in the request body change; anything omitted is left alone. Send
`dry_run` to validate the request without saving it.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Donors.UpdateAsync(new UpdateDonorV1Request { Id = 1 });
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `UpdateDonorV1Request` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Donors.<a href="/src/AwardSpring.Net/Donors/DonorsClient.cs">UpdateNotesAsync</a>(UpdateDonorNotesV1Request { ... }) -> WithRawResponseTask&lt;DonorNotesV1&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Replaces the donor's free-text notes. Returns `404 donor_not_found` if no such donor
belongs to this institution.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Donors.UpdateNotesAsync(new UpdateDonorNotesV1Request { Id = 1 });
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `UpdateDonorNotesV1Request` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Funds
<details><summary><code>client.Funds.<a href="/src/AwardSpring.Net/Funds/FundsClient.cs">ListAsync</a>(ListFundsRequest { ... }) -> WithRawResponseTask&lt;FundListItemV1ListResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Returns the funds belonging to the institution your API key is issued for, in the standard list envelope
(`object: "list"`, `has_more`, `next_cursor`, `previous_cursor`,
`data`). Page forward by passing the returned `next_cursor` as
`starting_after`. Filter with `?q=` (case-insensitive substring match on the
fund name).
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Funds.ListAsync(new ListFundsRequest());
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `ListFundsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Gifts
<details><summary><code>client.Gifts.<a href="/src/AwardSpring.Net/Gifts/GiftsClient.cs">ListAsync</a>(ListGiftsRequest { ... }) -> WithRawResponseTask&lt;GiftV1ListResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Returns one page at a time, newest first. Without filters the list covers the whole
institution. Narrow it with `donor_id` to scope to a single donor, `type` to
return only gifts or only pledges, and `q` to search the subject and description.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Gifts.ListAsync(new ListGiftsRequest());
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `ListGiftsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Gifts.<a href="/src/AwardSpring.Net/Gifts/GiftsClient.cs">CreateAsync</a>(CreateGiftV1Request { ... }) -> WithRawResponseTask&lt;GiftV1&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Gifts may also carry soft credits, which acknowledge someone other than the giver.
Send `dry_run` to validate the request without saving it, and an
`Idempotency-Key` header so a retry cannot record the same gift twice.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Gifts.CreateAsync(new CreateGiftV1Request());
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `CreateGiftV1Request` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Scholarships
<details><summary><code>client.Scholarships.<a href="/src/AwardSpring.Net/Scholarships/ScholarshipsClient.cs">ListAsync</a>(ListScholarshipsRequest { ... }) -> WithRawResponseTask&lt;ScholarshipListItemV1ListResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Returns the scholarships belonging to the institution your API key is issued for, in the list
envelope (`object: "list"`, `has_more`, `next_cursor`, `previous_cursor`,
`data`). Page forward by passing the returned `next_cursor` as `starting_after`;
the last page has `next_cursor: null`. `limit` defaults to 25 and is capped at 100.
Results are ordered by scholarship id ascending.
Filter with `?q=` (case-insensitive substring match on the scholarship name).
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Scholarships.ListAsync(new ListScholarshipsRequest());
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `ListScholarshipsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Scholarships.<a href="/src/AwardSpring.Net/Scholarships/ScholarshipsClient.cs">CreateAsync</a>(CreateScholarshipV1Request { ... }) -> WithRawResponseTask&lt;CreateScholarshipV1Response&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Creates a scholarship with its name, description, dates, financial totals, payment schedule,
department and donor associations, custom-field answers, and applicant-notification settings.
Errors come back with a stable `code`, a readable `message`, and per-field
`details`, so a caller can tell what to correct.


This endpoint enforces exactly the same rules as creating a scholarship in the AwardSpring
admin interface, so anything rejected here would also have been rejected there.


A typical call supplies the award's name, dates falling inside the active award cycle, a
budget total, and any donor association. The response returns the new
`scholarship_id`, which you can use in follow-up requests.


Set `dry_run=true` (query param or `Dry-Run: true` header) to validate without persisting.

<b>Idempotency:</b> the request supports an optional `Idempotency-Key` header (any
printable-ASCII string, 1–255 chars — UUIDs work well). When supplied, the same key plus
the same request body within 24 hours returns the original response verbatim without
creating a duplicate scholarship. The same key with a different body returns
`422 idempotency_key_request_mismatch`; a concurrent retry while the first call is
still executing returns `409 idempotency_key_in_flight`. Only 2xx responses are
cached — 4xx/5xx leave the key available for retry with a corrected payload.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Scholarships.CreateAsync(new CreateScholarshipV1Request { AwardCycleId = 1 });
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `CreateScholarshipV1Request` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Scholarships.<a href="/src/AwardSpring.Net/Scholarships/ScholarshipsClient.cs">ListAvailableDollarsAsync</a>(ListAvailableDollarsScholarshipsRequest { ... }) -> WithRawResponseTask&lt;ScholarshipAvailableDollarsV1ListResponse&gt;</code></summary>
<dl>
<dd>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Scholarships.ListAvailableDollarsAsync(new ListAvailableDollarsScholarshipsRequest());
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `ListAvailableDollarsScholarshipsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Scholarships.<a href="/src/AwardSpring.Net/Scholarships/ScholarshipsClient.cs">GetAvailableDollarsAsync</a>(GetAvailableDollarsScholarshipsRequest { ... }) -> WithRawResponseTask&lt;ScholarshipAvailableDollarsV1&gt;</code></summary>
<dl>
<dd>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Scholarships.GetAvailableDollarsAsync(
    new GetAvailableDollarsScholarshipsRequest { ScholarshipId = 1 }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `GetAvailableDollarsScholarshipsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Scholarships.<a href="/src/AwardSpring.Net/Scholarships/ScholarshipsClient.cs">ListAwardedStudentsAsync</a>(ListAwardedStudentsScholarshipsRequest { ... }) -> WithRawResponseTask&lt;AwardedStudentV1ListResponse&gt;</code></summary>
<dl>
<dd>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Scholarships.ListAwardedStudentsAsync(new ListAwardedStudentsScholarshipsRequest());
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `ListAwardedStudentsScholarshipsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

