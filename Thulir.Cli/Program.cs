﻿using Thulir.Cli.Commands;

var landsatCommands = new LandsatCommands();
// await landsatCommands.BuildLandsatDataCatalog();
await landsatCommands.CopyLandDataSets();