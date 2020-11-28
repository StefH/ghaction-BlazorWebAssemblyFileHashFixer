FROM sheyenrath/blazor-webassembly-filehash-fixer:2
COPY . .

RUN chmod +x ./fixer

ENTRYPOINT ["/fixer"]