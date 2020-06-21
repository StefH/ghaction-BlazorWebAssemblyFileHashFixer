# ghaction-BlazorWebAssemblyFileHashFixer

GitHub Action to fix the sha256 file-hashes in:
- blazor.boot.json
- service-worker-assets.js

## Inputs

### `wwwroot-path`

**Required** The path to the wwwroot folder. Default this is `.`.

## Example usage

``` yml
uses: stefh/blazor-webassembly-filehash-fixer@v1
with:
  wwwroot-path: '.'
```
