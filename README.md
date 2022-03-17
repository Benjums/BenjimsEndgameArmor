This is a JVL mod extending Epic Valheim's Additions to add armor sets crafted at Thor's Forge.  It is intended to be used in conjunction with Epic Valheim's Additions, Monsternomicon, and Forgotten Biomes.  It also modifies some weapon crafting recipies to try to create a more engaging gameplay loop, and attempts to rebalance endgame mob / boss health and damage to create challenges more appropriately matching the respective gear tiers.

This is mod a work in progress for the hosted server I play on with my friends.  It has currently only been tested in single player mode.  We'll probably need it in a couple weeks so my goal is to update this frequently.

Please note that between this mod and its dependencies there is a lot of code being run both when your game starts up and when you log into the world, so please be patient.  The debug log is a functional progress bar.  Forgotten Biomes is not literally a hard dependency, but the endgame zones will be much nicer with it and I recommend it highly.  No other mod files were changed in the creation of this.  All modifications to external content are handled via Harmony patches.

# Features

- New armor sets!  On-equip effects are not implemented yet for Glowing Plate, however, the flavor text hints at what I have in mind.
	- Heavymetal armor set - Mithril
	- Frometal armor set - Frostscale (note, effects for chest and boots are custom so they are hidden except for the flavor text clues)
	- Flametal armor set - Glowing Plate
- Gathering / crafting gameplay loop is implemented differently between tiers; will need playthrough testing to see which style feels more fun
	- Mistlands and Ashlands are the original Epic Valheim's Additions style of ore and World Tree Fragments a few other vanilla items.
	- New drops in Deep North that you can use to craft Frometal weapons and armor; see changelog for spoilers
- Tested damage and health values of Mistlands, Deep North, Ashlands mobs vs. new tier items and adjusted mob scaling to provide a more appropriate challenge.
	- I had some difficulty implementing this, please let me know if you find any issues.

# To Do, in a loose order of priority:

- Implement bonuses for Flametal
- Get a new mod icon
- Make new assets (currently using padded armor)
- Implement a config file

# Something not working?

Contact me at Benjims#7199 on Discord

# Special Thanks to:

- Alree, Belasias, and Huntard who respectively wrote Forgotten Biomes, Monsternomicon, and Epic Valheims Additions.  Their works form the core pillars of many endgame content mods, and like others I only stand on their shoulders.
- Margmas on the JVL Discord who showed me, more than once, how to access another mod's code with Harmony.  Without his help very little of this would have been possible for me to create.

# Changelog - Spoilers Ahead:
- ...
- ...
- ...
- ...
- ...
- ...
- ...
- ...
- ...
- ...
- ...
- ...
- v0.3.1
	- Edited Harmony Postfix declarations to match the updated class names in Epic Valheim's Additions 1.6.7
- v0.3.0
	- Added on-equip effects for Frometal armor
	- Increased durability for all endgame armor tiers, because the endgame mob scaling I implemented chunks the durability just like your health
- v0.2.2
	- Bugfixes
		- Gave Frostscale Boots their proper name
		- Fixed Flametal tier recipes so they appear at Thor's Forge
		- Iterated code for creature scaling
- v0.2.1
	- Cleaned up the readme
- v0.2.0
	- Slightly lowered Frometal armor values
		- Base armor was 2 points higher than max tier Heavymetal
	- Added Flametal armor
	- Revised mob health and damage values to provide more appropriate challenges for the Heavymetal, Frometal, and Flametal tiers
	- Specific mob changes can be viewed by decompiling the mod with ILSpy or a similar tool
- v0.1.0
	- Added new items and revised Monsternomicon's drop tables for creatures in the Deep North
		- Icy Fang from Fenrings
		- Polar Scale from Serpents
		- Frozen Pelt from Lox
		- Primordial Ice (from Epic Valheim's Additions) from Silver Golem
		- Deep North mobs drop more trophies than before, to help players with Epic Loot mod get more augmenting materials
	- Added these items to Frometal weapons and armor recipes
		- Weapons are from Epic Valheim's additions
- v0.0.2: 
	- Changed armor name from "Heavymetal" to "Mithril"
	- Rebalanced armor to match theme
		- Increased boot speed from 10% to 15%
		- Set all weights to 1
		- Reduced base armor from 36 to 32
		- Updated flavor text descriptions
	- Revised dependencies to note that this is a JVL mod; sorry to anyone who downloaded initially and if it didn't work
- v0.0.1: 
	- Initial release
