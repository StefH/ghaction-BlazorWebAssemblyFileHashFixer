FROM sheyenrath/blazor-webassembly-filehash-fixer
COPY . .

RUN chmod +x ./fixer

ENTRYPOINT ["./fixer"]