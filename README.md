# dota2-ult-overlay
## Add new hero
1. Download Hero and Ultimate images from official dota website (**Dont rename files**)\
   e.g. https://www.dota2.com/hero/ringmaster
3. Copy both image files to Resources\Images\\{Heroes/Ultimates}
4. Open csproj & set both image properties\
   a) Build Action = Content\
   b) Copy To Output Directory = Copy if newer
6. Add ultimate to '_cooldowns' dictionary\
e.g. { "wheel", 90 }
7. Rebuild project