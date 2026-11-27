# Product API Test Plan

## Scope

Verify the Product API's authenticated product lifecycle: list and read products, create, update, and delete. Cover role enforcement, missing resources, and duplicate names. Test data is held in memory for the test host and discarded when it closes; persistence, UI behavior, load/performance, and external identity-provider integration are out of scope.

## Test levels

- **Unit:** `ProductService` validation and repository interaction, plus basic product model behavior.
- **Integration:** HTTP requests through ASP.NET Core's test server, including routing, bearer-key authentication, role authorization, repository behavior, and response codes.
- **Shards:** Run the integration tests (`Shard=1`) and unit tests (`Shard=2`) as two independent jobs in parallel.

## Criteria

- **Pass:** All tests pass; create returns 201 with an ID, read/update return 200, delete returns 204, and a deleted or unknown ID returns 404.
- **Negative checks:** Missing credentials return 401; a reader attempting a write returns 403; a duplicate product name returns 409. Duplicate-name matching is case-insensitive.
- **Release gate:** Both shards complete successfully; a failing shard blocks acceptance.

## Risks and assumptions

- API keys are supplied through configuration (`Authentication:ApiKeys:ProductReader` and `Authentication:ApiKeys:ProductWriter`); do not commit real keys. A token's config key is its role. CI uses test-only values.
- The default repository is in-memory, so data is lost on restart and does not model database transactions or persistence failures.
- Product names are treated as unique without regard to case. If the business rule differs, update conflict behavior and its tests together.
- The Angular client currently has no credential flow. Authenticated writes require a separately designed client credential/login experience before end-to-end UI use.
