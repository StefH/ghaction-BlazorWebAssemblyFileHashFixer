FROM sheyenrath/blazor-webassembly-filehash-fixer
COPY . .

ENTRYPOINT ["/fixer"]