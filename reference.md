# Reference
## Applications
<details><summary><code>client.Applications.<a href="/src/AwardSpring.Net/Applications/ApplicationsClient.cs">ListAsync</a>(ListApplicationsRequest { ... }) -> WithRawResponseTask&lt;ApplicationV1ListResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Returns one page at a time. Each row names the scholarship and award cycle it belongs to,
and carries a `status` of `applied`, `awarded`, or `denied`. Without
filters the list covers the whole institution; narrow it with `user_id` (a
student's `id` from the Students endpoints) to scope to a single student. Returns
`404 student_not_found`, naming `user_id` in `param`, when the `user_id` is not
a student at this institution.

Assistant capability: `springiq_list_student_applications`. Required permission: Users (applies when called on behalf of a signed-in person).
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
await client.Applications.ListAsync(new ListApplicationsRequest());
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

**request:** `ListApplicationsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

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

Assistant capability: `springiq_list_award_cycles`.
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

Assistant capability: `springiq_get_current_award_cycle`.
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

## Awards
<details><summary><code>client.Awards.<a href="/src/AwardSpring.Net/Awards/AwardsClient.cs">ListAsync</a>(ListAwardsRequest { ... }) -> WithRawResponseTask&lt;AwardV1ListResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Returns one page at a time. Each row names the awarded scholarship and its award cycle,
and carries the awarded amount and decision date. Without filters the list covers the
whole institution; narrow it with `user_id` (a student's `id` from the
Students endpoints) to scope to a single student. Returns `404 student_not_found`,
naming `user_id` in `param`, when the `user_id` is not a student at this institution.

Assistant capability: `springiq_list_student_awards`. Required permission: Users (applies when called on behalf of a signed-in person).
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
await client.Awards.ListAsync(new ListAwardsRequest());
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

**request:** `ListAwardsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Departments
<details><summary><code>client.Departments.<a href="/src/AwardSpring.Net/Departments/DepartmentsClient.cs">ListAsync</a>(ListDepartmentsRequest { ... }) -> WithRawResponseTask&lt;DepartmentV1ListResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Returns the departments of the institution your API key is issued for, in the standard list envelope
(`object: "list"`, `has_more`, `next_cursor`, `previous_cursor`, `data`),
each with how many differently named scholarships and how many administrators belong to it. Page
forward by passing the returned `next_cursor` as `starting_after`. `limit` defaults to
25 and is capped at 100. Results are ordered by id ascending. Filter with `?q=`
(case-insensitive substring match on the department name).
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
await client.Departments.ListAsync(new ListDepartmentsRequest());
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

**request:** `ListDepartmentsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Departments.<a href="/src/AwardSpring.Net/Departments/DepartmentsClient.cs">CreateAsync</a>(CreateDepartmentV1Request { ... }) -> WithRawResponseTask&lt;DepartmentV1&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Adds one department, with the same rules as adding a department in the AwardSpring admin interface:
the name is required and must not already be used by another department at the institution, ignoring
upper and lower case and spaces at either end. A new department starts with the same settings the
admin interface gives one. Departments are not available on every plan; on a plan without them this
returns `403 permission_required`.

<b>Idempotency:</b> the request supports an optional `Idempotency-Key` header (any
printable-ASCII string, 1–255 chars — UUIDs work well). When supplied, the same key plus the same
request body within 24 hours returns the original response verbatim without creating a duplicate
department. The same key with a different body returns `422 idempotency_key_request_mismatch`; a
concurrent retry while the first call is still executing returns `409 idempotency_key_in_flight`.
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
await client.Departments.CreateAsync(new CreateDepartmentV1Request());
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

**request:** `CreateDepartmentV1Request` 
    
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

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Assistant capability: `springiq_list_donor_activities`. Required permission: Donors (applies when called on behalf of a signed-in person).
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
await client.DonorActivities.ListAsync(new ListDonorActivitiesRequest { DonorId = "donorId" });
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


Assistant capability: `springiq_create_activity`. Required permission: Donors (applies when called on behalf of a signed-in person).
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
await client.DonorActivities.CreateAsync(new CreateDonorActivityV1Request { DonorId = "donorId" });
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

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Assistant capability: `springiq_get_donor_activity`. Required permission: Donors (applies when called on behalf of a signed-in person).
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
await client.DonorActivities.GetAsync(
    new GetDonorActivitiesRequest { DonorId = "donorId", ActivityId = "activityId" }
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

Returns one page at a time. With no `sort` and no `q`, donors are listed by
`id`, lowest first.


Sort with `sort`. `name` lists donors A to Z, ignoring case: an organization by its
organization name, and a person by last name, then first name. A person with no last name
is listed by first name, and a donor with no name at all comes last. `last_contacted`
lists the most recently contacted donors first, by `last_contacted_at`; donors who
have never been contacted come last. Donors who tie are listed by `id`: lowest first
for `name`, highest first for `last_contacted`.


Narrow the list with `level` to donors at one or more levels, for example
`level=major,principal`. A donor's level comes from their giving, so a request made as
a signed-in user who may not see donors' giving returns `403 permission_denied` when
it filters by level. Sorting is open to everyone who can list donors.


Narrow the list with `giving_status` to donors with one or more giving statuses, for
example `giving_status=recurring,new`. `Recurring`: the donor has a recurring gift
that is still running (not cancelled or stopped, and not past its end date) and at least one
payment from it has gone through. `New`: the donor's first gift was in the last 12
months. `Lapsed`: the donor's last gift was more than 12 months ago. The 12 months count
back from now, not from the start of a fiscal year. A donor who fits more than one takes the
first of `Recurring`, `New`, `Lapsed`. A donor who has never given has no giving
status, and neither does one whose first gift was more than 12 months ago and who has given
again within the last 12 months. With `level` as well, a donor must match both. A
request made as a signed-in user who may not see donors' giving returns
`403 permission_denied` when it filters by giving status.


Search with `q` (at least `2` characters). Every word you type must match the
start of a word in the donor's first name, last name or organization, or the start of
their email address, so `jane smi` finds Jane Smith. Matches inside a word are not
found: `co` finds `Coworking` but not `Waco`. Where digits and letters
touch, a word is also split there, so `25co` finds `25N Coworking`.


Without `sort`, search results come in three groups: first, donors whose full name or
organization starts with the search (for a search with no spaces, compared with the spaces
taken out, so `janesmith` finds Jane Smith); next, donors where every word starts a
word in their name or organization; last, donors matched only through their email address.
Within a group, donors are listed by `id`, lowest first, so the order holds from one
page to the next. With `sort`, the search only decides which donors are listed and
the sort decides their order.

`sort`, `level`, `giving_status` and `q` work together. Send the same ones
on every page: a cursor sent with a different `sort`, `level`, `giving_status`
or `q` returns `400 invalid_cursor`. A search shorter than `2` characters, or an
unknown `level`, `giving_status` or `sort`, returns `400 validation_failed`
with `param` set to the parameter at fault.


Assistant capability: `springiq_list_donors`. Required permission: Donors (applies when called on behalf of a signed-in person).
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

Assistant capability: `springiq_create_donor`. Required permission: Donors (applies when called on behalf of a signed-in person).
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
gift, and their notes. `id` is the donor's stored ID. Returns `404 donor_not_found`
naming `id` if no such donor belongs to this institution.

Assistant capability: `springiq_get_donor_profile`. Required permission: Donors (applies when called on behalf of a signed-in person).
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
await client.Donors.GetAsync(new GetDonorsRequest { Id = "id" });
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
await client.Donors.UpdateAsync(new UpdateDonorV1Request { Id = "id" });
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

Replaces the donor's free-text notes. `id` is the donor's stored ID. Returns
`404 donor_not_found` naming `id` if no such donor belongs to this institution.
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
await client.Donors.UpdateNotesAsync(new UpdateDonorNotesV1Request { Id = "id" });
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

Assistant capability: `springiq_list_funds`. Required permission: Funds (applies when called on behalf of a signed-in person).
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
institution. Narrow it with `donor_id` (a donor's stored ID) to scope to a single donor, `type` to
return only gifts or only pledges, and `q` to search the subject and description.

Assistant capability: `springiq_list_gifts`. Required permission: Donors (applies when called on behalf of a signed-in person).
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

## Payment Schedules
<details><summary><code>client.PaymentSchedules.<a href="/src/AwardSpring.Net/PaymentSchedules/PaymentSchedulesClient.cs">ListAsync</a>(ListPaymentSchedulesRequest { ... }) -> WithRawResponseTask&lt;PaymentScheduleV1ListResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Returns the payment schedules belonging to the institution your API key is issued for, in the list
envelope (`object: "list"`, `has_more`, `next_cursor`, `previous_cursor`,
`data`). Page forward by passing the returned `next_cursor` as `starting_after`;
the last page has `next_cursor: null`. `limit` defaults to 25 and is capped at 100.
Results are ordered by payment-schedule id ascending; sort by `payment_date` to get the
order `payment_schedule_ids` expects. Filter with `?award_cycle_id=` to list only the
schedules configured on that award cycle; an award cycle the institution does not have returns
`404 award_cycle_not_found`.

Assistant capability: `springiq_list_payment_schedules`.
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
await client.PaymentSchedules.ListAsync(new ListPaymentSchedulesRequest());
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

**request:** `ListPaymentSchedulesRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## People
<details><summary><code>client.People.<a href="/src/AwardSpring.Net/People/PeopleClient.cs">ArchiveAsync</a>(ArchivePeopleRequest { ... }) -> WithRawResponseTask&lt;PersonV1&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Archives the account of a student or reviewer at the institution your API key is issued for. The person
cannot sign in until the account is restored; their applications, reviews and everything else are kept.
An API key can archive students and reviewers only: a person who holds any other role, such as an
administrator or a donor, returns `400 validation_failed`, and is archived in AwardSpring instead.
Archiving a person who is already archived changes nothing and returns the person. The archive is
recorded under your API key. An `id` that names no person at the institution returns
`404 person_not_found`, naming `id` in `param`.
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
await client.People.ArchiveAsync(new ArchivePeopleRequest { Id = "id" });
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

**request:** `ArchivePeopleRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.People.<a href="/src/AwardSpring.Net/People/PeopleClient.cs">RestoreAsync</a>(RestorePeopleRequest { ... }) -> WithRawResponseTask&lt;PersonV1&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Restores the archived account of a student or reviewer at the institution your API key is issued for, so
the person can sign in again. An API key can restore students and reviewers only: a person who holds any
other role returns `400 validation_failed`, and is restored in AwardSpring instead. Restoring a person
who is not archived changes nothing and returns the person. An `id` that names no person at the
institution returns `404 person_not_found`, naming `id` in `param`.
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
await client.People.RestoreAsync(new RestorePeopleRequest { Id = "id" });
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

**request:** `RestorePeopleRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.People.<a href="/src/AwardSpring.Net/People/PeopleClient.cs">ListAsync</a>(ListPeopleRequest { ... }) -> WithRawResponseTask&lt;PersonV1ListResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Returns the people the institution's Users list shows, for the institution your API key is issued
for, in the standard list envelope (`object: "list"`, `has_more`, `next_cursor`,
`previous_cursor`, `data`). Each person carries their roles, the departments an
administrator is limited to, whether the account is archived, and an administrator's permissions.
Page forward by passing the returned `next_cursor` as `starting_after`. `limit`
defaults to 25 and is capped at 100. Results are ordered by id ascending.


Filter with `?role=` (`administrators`, `reviewers`, `students` or
`donors`), `?q=` (part of a name, the start of an email address or student number, or an
exact id) and `?status=` (`all`, `active` or `archived`; archived accounts are
listed by default, as on the Users list).
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
await client.People.ListAsync(new ListPeopleRequest());
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

**request:** `ListPeopleRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Reviewers
<details><summary><code>client.Reviewers.<a href="/src/AwardSpring.Net/Reviewers/ReviewersClient.cs">CreateAsync</a>(CreateReviewerV1Request { ... }) -> WithRawResponseTask&lt;ReviewerV1&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Adds one reviewer account, with the same rules as adding a reviewer from the Users list in the AwardSpring
admin interface: a first name, a last name and a well-formed email are required, each at most 50
characters. As in the admin interface, a new reviewer gets no welcome email.

<b>An email that already has an account:</b> by default the email must not already be used by any account
at the institution, ignoring upper and lower case; if it is, this returns `400 email_already_exists`.
With `if_email_in_use` set to `add_role`, this does what the admin interface does instead, and no
second account is made. When an active account at the institution has the email, the reviewer role is added
to that account, which keeps its name, email and password, and this returns `200` with that account as
the reviewer. An account that already has the reviewer role is returned unchanged, also with `200`. The
role is never added to an account that holds an administrator role, and this returns
`400 email_already_exists` instead, as it does for an email whose account is deactivated, merged, or one
the admin interface would not change. When only an archived account has the email, that account gets no
role: a new reviewer is made with `201` and the email moves to them, as in the admin interface.
The `AwardSpring-Existing-Account` header says which of these happened: `role_added`,
`role_already_held` or `email_moved_from_archived`. It is absent for an ordinary create, and from
a response replayed for an `Idempotency-Key`.

<b>Idempotency:</b> the request supports an optional `Idempotency-Key` header (any
printable-ASCII string, 1–255 chars — UUIDs work well). When supplied, the same key plus the same
request body within 24 hours returns the original response verbatim without creating a duplicate
reviewer. The same key with a different body returns `422 idempotency_key_request_mismatch`; a
concurrent retry while the first call is still executing returns `409 idempotency_key_in_flight`.
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
await client.Reviewers.CreateAsync(new CreateReviewerV1Request());
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

**request:** `CreateReviewerV1Request` 
    
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

Assistant capability: `springiq_list_scholarships`. Required permission: Scholarships (applies when called on behalf of a signed-in person).
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


Assistant capability: `springiq_create_scholarship`. Required permission: Scholarships (applies when called on behalf of a signed-in person).
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
await client.Scholarships.CreateAsync(new CreateScholarshipV1Request());
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

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Assistant capability: `springiq_get_available_scholarship_dollars`. Required permission: Scholarships (applies when called on behalf of a signed-in person).
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
await client.Scholarships.ListAvailableDollarsAsync(
    new ListAvailableDollarsScholarshipsRequest { AwardCycleId = "award_cycle_id" }
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

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Assistant capability: `springiq_get_available_scholarship_dollars`. Required permission: Scholarships (applies when called on behalf of a signed-in person).
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
await client.Scholarships.GetAvailableDollarsAsync(
    new GetAvailableDollarsScholarshipsRequest
    {
        ScholarshipId = "scholarshipId",
        AwardCycleId = "award_cycle_id",
    }
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

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Assistant capability: `springiq_get_awarded_students`. Required permission: Scholarships (applies when called on behalf of a signed-in person).
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
await client.Scholarships.ListAwardedStudentsAsync(
    new ListAwardedStudentsScholarshipsRequest { AwardCycleId = "award_cycle_id" }
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

**request:** `ListAwardedStudentsScholarshipsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Students
<details><summary><code>client.Students.<a href="/src/AwardSpring.Net/Students/StudentsClient.cs">ListAsync</a>(ListStudentsRequest { ... }) -> WithRawResponseTask&lt;StudentV1ListResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Returns one page at a time, covering every student account at the institution — both
registered and prospective. Search with `q`: it splits on spaces and matches each
term against first name, last name, or email. Filter with `student_id` to look a
student up by the number the institution assigned; numbers are not guaranteed unique, so
the match can return more than one student.

Assistant capability: `springiq_list_students`. Required permission: Users (applies when called on behalf of a signed-in person).
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
await client.Students.ListAsync(new ListStudentsRequest());
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

**request:** `ListStudentsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Students.<a href="/src/AwardSpring.Net/Students/StudentsClient.cs">CreateAsync</a>(CreateStudentV1Request { ... }) -> WithRawResponseTask&lt;StudentV1&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Adds one student account, with the same rules as adding a student from the Users list in the AwardSpring
admin interface: a first name, a last name and a well-formed email are required, each at most 50
characters. An optional `student_id` must not already be on another account. The new student gets the
same welcome email the admin interface sends, with a link to set a password.

<b>An email that already has an account:</b> by default the email must not already be used by any account
at the institution, ignoring upper and lower case; if it is, this returns `400 email_already_exists`.
With `if_email_in_use` set to `add_role`, this does what the admin interface does instead, and no
second account is made. When an active account at the institution has the email, the student role is added
to that account, which keeps its name, email, password and student ID (a `student_id` sent with the request
is still checked against other accounts but is not saved), and this returns `200` with that account as
the student. An account that already has the student role is returned unchanged, also with `200`. The
role is never added to an account that holds an administrator role, and this returns
`400 email_already_exists` instead, as it does for an email whose account is deactivated, merged, or one
the admin interface would not change. When only an archived account has the email, that account gets no
role: a new student is made with `201` and the email moves to them, as in the admin interface.
The `AwardSpring-Existing-Account` header says which of these happened: `role_added`,
`role_already_held` or `email_moved_from_archived`. It is absent for an ordinary create.

<b>Welcome email:</b> the response carries an `AwardSpring-Welcome-Email` header. It is `queued`
when the email is on its way, `not_sent` when it could not be sent, and `none` when the role went
onto an account that already had the email (`if_email_in_use` set to `add_role`), which gets no
welcome email. The student is created either way; for
`not_sent`, send them a set-password link with Reset Password on their account in the admin
interface. A response replayed for an `Idempotency-Key` carries neither header.

<b>Idempotency:</b> the request supports an optional `Idempotency-Key` header (any
printable-ASCII string, 1–255 chars — UUIDs work well). When supplied, the same key plus the same
request body within 24 hours returns the original response verbatim without creating a duplicate
student. The same key with a different body returns `422 idempotency_key_request_mismatch`; a
concurrent retry while the first call is still executing returns `409 idempotency_key_in_flight`.
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
await client.Students.CreateAsync(new CreateStudentV1Request());
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

**request:** `CreateStudentV1Request` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Students.<a href="/src/AwardSpring.Net/Students/StudentsClient.cs">GetAsync</a>(GetStudentsRequest { ... }) -> WithRawResponseTask&lt;StudentV1&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Fetches one student by their `id` from the students list. Returns
`404 student_not_found`, naming `id` in `param`, if no such student belongs to this
institution.

Assistant capability: `springiq_get_student`. Required permission: Users (applies when called on behalf of a signed-in person).
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
await client.Students.GetAsync(new GetStudentsRequest { Id = "id" });
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

**request:** `GetStudentsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

