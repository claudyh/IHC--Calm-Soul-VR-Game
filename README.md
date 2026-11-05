## Calm Soul
*in Unity (Virtual Reality)*

&nbsp;

### 📋 **Project Description**

---

Calm Soul is a Virtual Reality relaxation game that helps players deal with negative emotions (anxiety, stress, frustration...) through guided exercises in calm, immersive environments. Each level is associated with an emotion and has its own relaxation exercise, such as deep breathing or progressive muscle relaxation. The game was thought to have two modes: a story/base mode, where levels are unlocked as emotions are managed, and an endless mode, where the player chooses a level and plays it for as long as needed.

The project was developed in three stages:

- **Stage 1 - Context and Concept:** Definition of the concept and design of the game: interpretation of the challenge, design proposal, Activity Theory and HAM models, prioritized list of user tasks and first interaction sketches (paper prototype) of the menus and levels.
- **Stage 2 - Demo Prototyping:** Wizard of Oz test of the paper prototype of the breathing level, with feedback from participants. This stage also included the planning of the tasks and the first Unity demo of level 1, with the menus and the breathing mechanic.
- **Stage 3 - Final Prototype and UX Evaluation:** Final Unity prototype and usability evaluation with 10 participants, following a formal lab testing protocol.

**Note:** Images of the prototype are present in the `Images` folder.

&nbsp;

### 🎮 **Prototype**

---

**Menus**
- **Start menu**, on a small island where the player begins: play, settings and exit.
- **Level selection menu**, where levels that are not implemented yet appear discolored.
- **Settings menu**, with the audio volume, language (only English for now) and images of the game controls.

**Level 1 - Anxiety**

The player walks through a forest surrounded by mountains, with relaxing background music, following a path with floating orbs:
- **Orange orbs:** breathe in. **Blue orbs:** breathe out.
- When the player gets close to an orb, a progress bar appears (always facing the player) with a "breathe in" or "breathe out" text, and fills as long as the player holds the matching button, with breathing sounds.
- After the bar is filled, the orb is attracted to the player, so there is no need to touch it.
- At the end of the path, a panel announces the end of the level, and a special orb takes the player back to the start island.

**Controls**

| Action | Control |
|---|---|
| Move the player | Left joystick |
| Move the camera | Right joystick |
| Breathe in (orange orbs) | Right trigger |
| Breathe out (blue orbs) | Right grip |
| Next menu / tutorial panel | Button A |
| Close menu | Button Y |

&nbsp;

### 🚧 **Future Work**

---

- Procedural generation of content so the game does not become repetitive.
- Other emotion levels (e.g. Stress, with body relaxation movements, and Overwhelm, with painting by numbers).

&nbsp;

---

**NOTE:** This project was developed and tested with the Meta VR glasses. All the visual and audio assets come from the Unity Asset Store (all free to use). This project was developed within the scope of a Computer Science course by Afonso Rodrigues, André Louro, Cláudia Torres and Maria João Rosa.
