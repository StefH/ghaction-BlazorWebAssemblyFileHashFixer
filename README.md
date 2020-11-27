# ghaction-BlazorWebAssemblyFileHashFixer

GitHub Action to fix the sha256 file-hashes in:
- blazor.boot.json
- service-worker-assets.js

## Why

In case you deploy your Blazor WebAssembly application on GitHub Pages and do one the modifications below:
 - [SteveSandersonMS/ghaction-rewrite-base-href](https://github.com/SteveSandersonMS/ghaction-rewrite-base-href)
 - [show-a-loading-progress-indicator-for-a-blazor-webassembly-application](https://medium.com/@stef.heyenrath/show-a-loading-progress-indicator-for-a-blazor-webassembly-application-ea28595ff8c1)

The index.html and/or .js files are modified.
And when running the Blazor WebAssembly using a service-worker, you can get this error in the console:

```
Failed to find a valid digest in the 'integrity' attribute for resource 'https://stefh.github.io/xxx/index.html' with computed SHA-256 integrity '/C6AMmjXzNTqgqy8YOF4zcMbioqALgdg/bbhWojItcw='. The resource has been blocked.
Unknown error occurred while trying to verify integrity.
service-worker.js:1 Uncaught (in promise) TypeError: Failed to fetch
```

## Solution

Use this GitHub Action to fix the SHA56 hashes in the `blazor.boot.json` and `service-worker-assets.js` files.

## Usage

### Inputs

#### `wwwroot-path`

**Required** The path to the wwwroot folder. Default this is `.`.

### Example

``` yml
- name: BlazorWebAssemblyFileHashFixer
  uses: stefh/ghaction-BlazorWebAssemblyFileHashFixer@v1
  with:
    wwwroot-path: ${{ env.PUBLISH_DIR }}
```