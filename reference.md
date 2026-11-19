# Reference
## Applications
<details><summary><code>client.Applications.<a href="/src/AwardSpring.Net/Applications/ApplicationsClient.cs">ListAsync</a>(ListApplicationsRequest { ... }) -> Pager&lt;ApplicationV1&gt;</code></summary>
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
<details><summary><code>client.AwardCycles.<a href="/src/AwardSpring.Net/AwardCycles/AwardCyclesClient.cs">ListAsync</a>(ListAwardCyclesRequest { ... }) -> Pager&lt;AwardCycleV1&gt;</code></summary>
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

<details><summary><code>client.AwardCycles.<a href="/src/AwardSpring.Net/AwardCycles/AwardCyclesClient.cs">GetAvailableDollarsSummaryAsync</a>(GetAvailableDollarsSummaryAwardCyclesRequest { ... }) -> WithRawResponseTask&lt;AvailableDollarsSummaryV1&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Returns one available-dollars summary (`object: "available_dollars_summary"`): the budget, awarded and remaining amounts of
every active scholarship in the award cycle added together, and how many of those scholarships are
over-awarded. The totals add up the same scholarships and amounts that
`GET /api/v1/scholarships/available-dollars` lists for the same cycle, so use this endpoint for a
cycle-wide total instead of paging through that list. An over-awarded scholarship (one that has awarded
more than its budget) is included and counts against `total_amount_remaining`. A cycle with no
active scholarships returns zeros, not an error. An award cycle ID the institution does not have returns
`404 award_cycle_not_found` naming `awardCycleId`; to find the cycle running now, call
`GET /api/v1/award-cycles/current`.

Assistant capability: `springiq_get_available_dollars_summary`. Required permission: Scholarships (applies when called on behalf of a signed-in person).
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
await client.AwardCycles.GetAvailableDollarsSummaryAsync(
    new GetAvailableDollarsSummaryAwardCyclesRequest { AwardCycleId = "awardCycleId" }
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

**request:** `GetAvailableDollarsSummaryAwardCyclesRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Awards
<details><summary><code>client.Awards.<a href="/src/AwardSpring.Net/Awards/AwardsClient.cs">ListAsync</a>(ListAwardsRequest { ... }) -> Pager&lt;AwardV1&gt;</code></summary>
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
<details><summary><code>client.Departments.<a href="/src/AwardSpring.Net/Departments/DepartmentsClient.cs">ListAsync</a>(ListDepartmentsRequest { ... }) -> Pager&lt;DepartmentV1&gt;</code></summary>
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
<details><summary><code>client.DonorActivities.<a href="/src/AwardSpring.Net/DonorActivities/DonorActivitiesClient.cs">ListAsync</a>(ListDonorActivitiesRequest { ... }) -> Pager&lt;DonorActivityV1&gt;</code></summary>
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
`LoggedPledge`. Gifts are recorded through the Gifts endpoints instead. A pledge for an archived donor,
whether the account is archived or only its Donor role, returns `400 validation_failed`; restore the
donor first. Other activity types are recorded for an archived donor.


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
<details><summary><code>client.Donors.<a href="/src/AwardSpring.Net/Donors/DonorsClient.cs">ListAsync</a>(ListDonorsRequest { ... }) -> Pager&lt;DonorListItemV1&gt;</code></summary>
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
have never been contacted come last. `longest_since_contact` is the other way round: donors
never contacted first, then the oldest contact. Donors who tie are listed by `id`: lowest
first for `name` and `longest_since_contact`, highest first for `last_contacted`.


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


To keep a copy in sync, send `changed_since`, a time in UTC epoch seconds. The list then holds
only the donors whose stored details changed at or after that time, in the order they changed,
oldest change first, by `last_changed_at`. A new gift does not count as a change to its donor.
Archiving or restoring a donor counts as a change: an archived donor stays in the list with
`archived: true`, including one who is a donor only through an extra Donor role, and comes back
with `archived: false` once restored. A donor removed since that time is listed too, at the time it was removed, with only
`object`, `id`, `deleted: true` and `removed_at`. That includes a person who stops
being a donor but keeps their account, for example when their Donor role is removed; their gifts are
not removed with it. If that person becomes a donor again, the same `id` is listed again as a
change, after its removal. A removed donor keeps no
giving, so a list narrowed by `level` or `giving_status` leaves removals out: keep one
sync with no other filter to learn of them. Every page carries `complete_up_to`, the same on
every page of one walk; start the next sync from it. A donor may appear in two syncs in a row, but
none is missed.

`changed_since` works with `level` and `giving_status`. With `sort` or
`q` it returns `400 validation_failed` with `param` naming the parameter it cannot
be combined with. A time in the future, or anything but a whole number of seconds, returns
`400 validation_failed` with `param` set to `changed_since`. A cursor sent with a
different `changed_since` returns `400 invalid_cursor`.


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
gift, their notes, the tags on the donor, and their answers to the institution's donor custom
fields. `id` is the donor's stored ID. Returns `404 donor_not_found`
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
`dry_run` to validate the request without saving it. `id` takes any donor
`GET /api/v1/donors/{id}` returns, an archived one included; the donor stays archived.

<b>Administrator accounts:</b> a program with an API key never changes an account that holds an
administrator role. A donor who is also an administrator returns `400 validation_failed` naming
`id`, and nothing is saved; change them in AwardSpring instead.
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

Replaces the donor's free-text notes. `id` is the donor's stored ID, and takes any donor
`GET /api/v1/donors/{id}` returns, an archived one included. Returns
`404 donor_not_found` naming `id` if no such donor belongs to this institution.

<b>Administrator accounts:</b> a program with an API key never changes an account that holds an
administrator role. A donor who is also an administrator returns `400 validation_failed` naming
`id`, and the notes are not saved; change them in AwardSpring instead.
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
<details><summary><code>client.Funds.<a href="/src/AwardSpring.Net/Funds/FundsClient.cs">ListAsync</a>(ListFundsRequest { ... }) -> Pager&lt;FundListItemV1&gt;</code></summary>
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
<details><summary><code>client.Gifts.<a href="/src/AwardSpring.Net/Gifts/GiftsClient.cs">ListAsync</a>(ListGiftsRequest { ... }) -> Pager&lt;GiftV1&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Returns one page at a time. Without filters the list covers the whole
institution. Narrow it with `donor_id` (a donor's stored ID) to scope to a single donor, `type` to
return only gifts or only pledges, and `q` to search the subject and description, the donor's
name, organization or email, and the fund's name. `donor_id` takes any donor
`GET /api/v1/donors/{id}` returns, an archived one included.


With no `sort`, gifts are listed in the order they were recorded, earliest recorded first.
Sort by gift `date` with `sort`: `date_desc` lists the newest gift date first and
`date_asc` the oldest first. Gifts that share a date keep the same order from one page
to the next: the most recently recorded first for `date_desc`, the earliest recorded first
for `date_asc`.

`sort`, `donor_id`, `type` and `q` work together. Send the same ones on every
page: a cursor sent with a different `sort`, `donor_id`, `type` or `q` returns
`400 invalid_cursor`. An unknown `sort` returns `400 validation_failed` with
`param` set to `sort`.


To keep a copy in sync, send `changed_since`, a time in UTC epoch seconds. The list then holds
only the gifts and pledges that changed at or after that time, in the order they changed, oldest
change first, by `last_changed_at`. A gift or pledge removed since that time is listed too, at
the time it was removed, with only `object`, `id`, `deleted: true` and
`removed_at`. A list narrowed by `donor_id` lists that donor's removed gifts and pledges. A
removed gift keeps no type, so a list narrowed by `type` leaves removals out: keep one sync
without `type` to learn of them. A gift or pledge that moved to another donor, or switched between
gift and pledge, is listed the same way in a list narrowed by the `donor_id` or `type` it
left, at the time it changed, unless it matches that list again by then; it stays live in every other
list, and a list with neither filter never lists it removed. Every page carries `complete_up_to`, the same on every
page of one walk; start the next sync from it. A gift may appear in two syncs in a row, but none is
missed.

`changed_since` works with `donor_id` and `type`. With `sort` or `q` it
returns `400 validation_failed` with `param` naming the parameter it cannot be combined
with. A time in the future, or anything but a whole number of seconds, returns
`400 validation_failed` with `param` set to `changed_since`. A cursor sent with a
different `changed_since` returns `400 invalid_cursor`.


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

<details><summary><code>client.Gifts.<a href="/src/AwardSpring.Net/Gifts/GiftsClient.cs">GetAsync</a>(GetGiftsRequest { ... }) -> WithRawResponseTask&lt;GiftV1&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Fetches one gift or pledge by its `id` from the gifts list, with the same fields and values
the list returns for it. Returns `404 gift_not_found`, naming `id` in `param`, when
no gift or pledge with that ID belongs to this institution, including when the ID belongs to
another kind of logged activity such as an email or a meeting.
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
await client.Gifts.GetAsync(new GetGiftsRequest { Id = "id" });
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

**request:** `GetGiftsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Gifts.<a href="/src/AwardSpring.Net/Gifts/GiftsClient.cs">UpdateAsync</a>(UpdateGiftV1Request { ... }) -> WithRawResponseTask&lt;GiftV1&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Changes a gift's or pledge's amount, gift date, payment type, fund, campaign, subject and description,
with the same rules the gift's edit window applies. Send only the fields to change: a field left out
keeps its value. Send an empty string to clear `fund_id`, `campaign_id` or
`description`; the other fields cannot be cleared.


The donor, the record type (`type`), soft credits, `is_completed`,
`assigned_to_user_id`, `gift_acknowledgement_sent` and any field not listed in the request
body cannot be changed here. A request that sends one, or a value that is refused, returns
`400 validation_failed`, and nothing in the request is saved. Each refused field is named in
`details`, and in `param` when only one field is refused; a refusal from the gift's own save rules
(for example a zero amount, or a closed fund) names no field.
On a gift given online, the amount, gift date and payment type cannot be changed; its other fields can.
A pledge has no payment type, and `Online` cannot be chosen as a payment type.


Returns the gift or pledge as `GET /api/v1/gifts/{id}` returns it after the change. Returns
`404 gift_not_found`, naming `id` in `param`, when no gift or pledge with that ID belongs
to this institution. Send `dry_run` to check the change and see the result without saving it,
and an `Idempotency-Key` header so a retry returns the first answer.
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
await client.Gifts.UpdateAsync(new UpdateGiftV1Request { Id = "id" });
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

**request:** `UpdateGiftV1Request` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Payment Schedules
<details><summary><code>client.PaymentSchedules.<a href="/src/AwardSpring.Net/PaymentSchedules/PaymentSchedulesClient.cs">ListAsync</a>(ListPaymentSchedulesRequest { ... }) -> Pager&lt;PaymentScheduleV1&gt;</code></summary>
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
Each schedule's `id` is its stored ID (9 characters, capital letters and numbers): pass it
exactly as returned in a scholarship's `payment_schedule_ids`. Results come in the order the
schedules were created; sort by `payment_date` to get the order `payment_schedule_ids`
expects. Filter with `?award_cycle_id=` to list only the schedules configured on that award
cycle; an award cycle the institution does not have returns `404 award_cycle_not_found`.

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

<details><summary><code>client.People.<a href="/src/AwardSpring.Net/People/PeopleClient.cs">ListAsync</a>(ListPeopleRequest { ... }) -> Pager&lt;PersonV1&gt;</code></summary>
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

## Review Groups
<details><summary><code>client.ReviewGroups.<a href="/src/AwardSpring.Net/ReviewGroups/ReviewGroupsClient.cs">ListAsync</a>(ListReviewGroupsRequest { ... }) -> Pager&lt;ReviewGroupV1&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Returns the review groups of one award cycle, in the standard list envelope. `award_cycle_id` is
required and is the award cycle's stored ID. Each group shows its stored ID, its name and its award cycle.
An award cycle the institution does not have returns `404 award_cycle_not_found`.
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
await client.ReviewGroups.ListAsync(
    new ListReviewGroupsRequest { AwardCycleId = "award_cycle_id" }
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

**request:** `ListReviewGroupsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Reviewer Assignments
<details><summary><code>client.ReviewerAssignments.<a href="/src/AwardSpring.Net/ReviewerAssignments/ReviewerAssignmentsClient.cs">ListAsync</a>(ListReviewerAssignmentsRequest { ... }) -> Pager&lt;ReviewerAssignmentV1&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Returns one row per pair, as the Reviewer Assignment tab shows them, in the standard list envelope. Each row
has the group's name and award cycle, the panel number on a group with two panels, and the reviewer and the
applicant with name, email and stored ID. Rows are ordered by panel, then reviewer, then applicant.


Name the group by `review_group_id`, its stored ID, or by `review_group_name`, optionally with
`award_cycle_id`; leaving both out returns `400 validation_failed`. A group that does not exist at
your institution, including one from another institution, returns `404 review_group_not_found`, and so
does a name that fits no group. A name that fits more than one group returns `400 validation_failed`
naming each. Leave `panel` out to list every panel; send `panel` to list one. A panel the group
does not have returns `404 review_group_panel_not_found`. Send the same filters on every page: they are
recorded in the cursor, and a page request whose filters do not match the cursor's is refused.


Assistant capability: `springiq_list_reviewer_assignments`.
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
await client.ReviewerAssignments.ListAsync(new ListReviewerAssignmentsRequest());
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

**request:** `ListReviewerAssignmentsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.ReviewerAssignments.<a href="/src/AwardSpring.Net/ReviewerAssignments/ReviewerAssignmentsClient.cs">ChangeAsync</a>(ChangeReviewerAssignmentsV1Request { ... }) -> WithRawResponseTask&lt;ChangeReviewerAssignmentsV1Result&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Changes the pairs on one panel of a review group, with the same rules as the Reviewer Assignment tab.
`review_group_id` in the body is required and is the review group's stored ID. Name each person by
email or stored ID. Set `mode` to `add`, `remove` or `replace`; `replace` makes the
panel hold exactly the pairs you send, removing the others.

<b>Checks on every row.</b> The reviewer must already be a reviewer in the group. The applicant must have
applied to a scholarship in the group, and on panel 2 must have been moved up to it. A reviewer is never
given their own application. A pair listed twice, or a person who matches no active account or more than
one, is turned down. A `replace` that would remove a pair whose review is started or finished turns
that pair down unless `allow_removing_started_reviews` is `true`; removing a pair also removes
that reviewer's scores for it, as Unassign does on the tab. Only a pair the tab shows is already in place
or there to remove: adding a pair the tab does not show is turned down, and removing one leaves it as it
is and counts it as `unchanged`.

<b>All or nothing.</b> If any row is turned down, nothing changes and the answer is
`400 assignment_rows_rejected`, whose `details` list every row with its reason. Rows that pass
show `not_applied`. With `apply_good_rows_only` set to `true`, the rows that pass are
applied and each turned-down row is listed in the `200`. A `replace` is the exception: one row
whose reviewer or applicant matches no active account, or more than one, refuses the whole request with
`400 assignment_rows_rejected` even with `apply_good_rows_only`, because that row could name a
pair the panel holds and a `replace` removes every pair it does not list.

<b>Large requests.</b> A request with more than 500 rows, or more than 500 pairs to change, is accepted at
once with `202` and a `reviewer_assignment_job`, which names the review group and its award
cycle as every answer does. Read `status_url` to follow it. Under
all-or-nothing, a pair that becomes invalid while the job runs stops the job: batches already written
stay written, and the job says so. At most 20,000 rows are accepted in one request, and a request may
cover at most 20,000 pairs counting the pairs a `replace` removes because the request leaves them out;
a larger one is refused with `400 validation_failed`.

<b>The panel's assignment choice is never changed.</b> Every answer shows it as `assignment_choice`.
When it is `all` or `random`, the answer carries a `warning`: applying that choice again in
AwardSpring would replace the pairs you loaded.


Each pair added is recorded as added by your API key. Send `dry_run` to check the request without
changing anything, and an `Idempotency-Key` header so a retry returns the original answer; for a
background job, the same job. Sending the same request again also ends in the same pairs.
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
await client.ReviewerAssignments.ChangeAsync(new ChangeReviewerAssignmentsV1Request());
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

**request:** `ChangeReviewerAssignmentsV1Request` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.ReviewerAssignments.<a href="/src/AwardSpring.Net/ReviewerAssignments/ReviewerAssignmentsClient.cs">GetJobAsync</a>(GetJobReviewerAssignmentsRequest { ... }) -> WithRawResponseTask&lt;ReviewerAssignmentJobV1&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Shows how a background request is going: `status`, how many of its rows are done, and the counts so
far. Like every answer about pairs, it names the review group and its award cycle by stored ID and name.
The job carries totals only; read `rows_url` for each row's result. `completed` means every
row was applied. A job that stopped early, or has any turned-down or failed row, including rows turned down
when the request was accepted, is `partially_completed` and says why in `notices`. A job that
applied nothing because it could not run, or because every row it reached was turned down or failed, is
`failed`. A job code that names no job at your institution, including another institution's, returns
`404 assignment_job_not_found`.
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
await client.ReviewerAssignments.GetJobAsync(
    new GetJobReviewerAssignmentsRequest { JobId = "job_id" }
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

**request:** `GetJobReviewerAssignmentsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.ReviewerAssignments.<a href="/src/AwardSpring.Net/ReviewerAssignments/ReviewerAssignmentsClient.cs">ListJobRowsAsync</a>(ListJobRowsReviewerAssignmentsRequest { ... }) -> Pager&lt;ReviewerAssignmentJobRowV1&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Returns a background request's rows in request order, in the standard list envelope, each with what has
happened to it so far: `waiting` until the job reaches it, then `applied`, `rejected` or
`failed` with a `message` saying why. A row an all-or-nothing job never reached, because a pair
failed its final check, stays `waiting`. When a job stops for any other reason, such as the API key
losing its write access or the job being unable to finish, a row it did not change is `rejected`
with a `message` saying why, and a row whose pair already stands as asked is `applied`. Pairs a
`replace` removes because the request leaves them out come after the
request's own rows and have no `index`.

`job_id` is required and is the job's code from its `status_url`. A code that names no job at your
institution, including another institution's, returns `404 assignment_job_not_found`.
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
await client.ReviewerAssignments.ListJobRowsAsync(new ListJobRowsReviewerAssignmentsRequest());
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

**request:** `ListJobRowsReviewerAssignmentsRequest` 
    
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
<details><summary><code>client.Scholarships.<a href="/src/AwardSpring.Net/Scholarships/ScholarshipsClient.cs">ListAsync</a>(ListScholarshipsRequest { ... }) -> Pager&lt;ScholarshipListItemV1&gt;</code></summary>
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

<details><summary><code>client.Scholarships.<a href="/src/AwardSpring.Net/Scholarships/ScholarshipsClient.cs">GetAsync</a>(GetScholarshipsRequest { ... }) -> WithRawResponseTask&lt;ScholarshipV1&gt;</code></summary>
<dl>
<dd>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Scholarships.GetAsync(new GetScholarshipsRequest { ScholarshipId = "scholarshipId" });
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

**request:** `GetScholarshipsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Scholarships.<a href="/src/AwardSpring.Net/Scholarships/ScholarshipsClient.cs">UpdateAsync</a>(UpdateScholarshipV1Request { ... }) -> WithRawResponseTask&lt;ScholarshipV1&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Changes a scholarship's name, application open and close dates, department, fund, donors, description,
award notification wording, custom field values and qualifications (`add_qualifications` and
`remove_qualifications`), and returns the updated scholarship in the same shape as getting it. Only the
fields in the body change: a field left out, or sent as `null`, stays as it is, and an empty string
clears a field only where the scholarship's Details tab lets it be cleared (the department, the fund and a
custom field's value).


The same rules apply as when an administrator saves the scholarship's Details tab, so anything refused there
is refused here. Every field is checked before anything is saved, and the changes are saved together or not
at all: a request with one refused field saves nothing, and the error names each refused field in
`details`. A field this call does not change (for example `total_amount`) is refused the same way.


A date sent without a time is that calendar day in the institution's time zone, and the scholarship keeps
the time of day it opens or closes at now. A scholarship that starts taking applications again because of
the change has its student matching and auto-apply run shortly after the save, as on the Details tab.

`remove_qualifications` and `add_qualifications` name groups by their `group_number` in the
scholarship's `qualification_groups` as last read, and the rules are saved by the Qualifications tab's own
save, so its checks apply. Qualifications change only while the scholarship is taking applications, and the
request is refused if either its stored close date has passed or the `application_end_date` it sends is
in the past: reopening a closed scholarship and changing its qualifications in one request is refused, so
reopen it first and change the qualifications in a second call. Students are re-checked against
changed qualifications shortly after the save. A question behind a qualification always carries its stored
ID; a question found without one is a server error (500).


A scholarship ID the institution does not have, or that is malformed, returns `404 scholarship_not_found`
naming `id`. The call needs an API key with write permission.


Set `dry_run=true` (query param or `Dry-Run: true` header) to check the changes and see the
scholarship as it would be, without saving anything.

<b>Idempotency:</b> the request supports an optional `Idempotency-Key` header (any printable-ASCII
string, 1–255 chars). The same key plus the same request body within 24 hours returns the original response
without changing the scholarship again. The same key with a different body returns
`422 idempotency_key_request_mismatch`; a concurrent retry while the first call is still executing
returns `409 idempotency_key_in_flight`. Only 2xx responses are cached.
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
await client.Scholarships.UpdateAsync(
    new UpdateScholarshipV1Request { ScholarshipId = "scholarshipId" }
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

**request:** `UpdateScholarshipV1Request` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Scholarships.<a href="/src/AwardSpring.Net/Scholarships/ScholarshipsClient.cs">ListAvailableDollarsAsync</a>(ListAvailableDollarsScholarshipsRequest { ... }) -> Pager&lt;ScholarshipAvailableDollarsV1&gt;</code></summary>
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

<details><summary><code>client.Scholarships.<a href="/src/AwardSpring.Net/Scholarships/ScholarshipsClient.cs">ListAwardedStudentsAsync</a>(ListAwardedStudentsScholarshipsRequest { ... }) -> Pager&lt;AwardedStudentV1&gt;</code></summary>
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
<details><summary><code>client.Students.<a href="/src/AwardSpring.Net/Students/StudentsClient.cs">ListAsync</a>(ListStudentsRequest { ... }) -> Pager&lt;StudentV1&gt;</code></summary>
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

<details><summary><code>client.Students.<a href="/src/AwardSpring.Net/Students/StudentsClient.cs">UpdateAsync</a>(UpdateStudentV1Request { ... }) -> WithRawResponseTask&lt;StudentV1&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Changes a student's `first_name`, `last_name`, `email`, `student_id` and `phone`,
with the same checks as changing them on the student's account in the AwardSpring admin interface. The
student is named by their `id` from the students list. The change is recorded under your API key.

<b>Only what you send changes:</b> a field left out of the body, or sent as `null`, stays as it is.
An empty `phone` or `student_id` clears it. A name or email cannot be cleared: an empty one returns
`400 validation_failed` naming the field. Any other field in the body, such as `gpa`, returns
`400 validation_failed` naming it, and nothing is saved.

<b>What is refused:</b> a `student_id` already on another account at the institution, a value longer
than its limit, or a malformed email returns `400 validation_failed` naming the field. An email any
other account at the institution has, ignoring upper and lower case and including an archived account,
returns `400 email_already_exists` naming `email`. Changing the email changes how the student
signs in, and no email is sent to them about it. A refused request saves nothing.

<b>Administrator accounts:</b> a program with an API key never changes an account that holds an
administrator role. A student who is also an administrator returns `400 validation_failed` naming
`id`; change them in AwardSpring instead.


An `id` that names no student at the institution, including a donor's or reviewer's `id`,
returns `404 student_not_found`, naming `id` in `param`. Send `dry_run` to run every
check without saving: the response shows the student as the change would leave them. The student resource
has no phone, so a phone change does not appear in the response.

<b>Idempotency:</b> the request supports an optional `Idempotency-Key` header (any
printable-ASCII string, 1–255 chars — UUIDs work well). When supplied, the same key plus the same
request body within 24 hours returns the original response verbatim without changing the student again.
The same key with a different body returns `422 idempotency_key_request_mismatch`; a concurrent retry
while the first call is still executing returns `409 idempotency_key_in_flight`.
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
await client.Students.UpdateAsync(new UpdateStudentV1Request { Id = "id" });
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

**request:** `UpdateStudentV1Request` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

