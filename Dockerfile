FROM sheyenrath/blazor-webassembly-filehash-fixer
COPY fixer /fixer

ENTRYPOINT ["/fixer"]