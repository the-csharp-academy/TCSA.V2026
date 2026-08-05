# C# for Unity Course Outline

## Course direction

This course continues the simple top-down collection game from the first Unity course. Students should improve a familiar project instead of starting over.

The goal is a gentle introduction to practical C# concepts that make the game easier to understand and extend. Every lesson should produce a small, visible improvement.

## Course progression

### 1. Clean up the existing scripts

- Review movement, collectibles, scoring, and winning.
- Split large scripts into focused components.
- Introduce private fields, properties, and small methods.

### 2. Add different collectibles

- Add coins and bonus items.
- Create a base `Collectible` class.
- Introduce inheritance through an immediate gameplay change.

### 3. Track collectibles with a list

- Store the items the player has collected.
- Display how many items of each type were collected.
- Introduce `List<T>`, loops, and basic collection operations.

### 4. Add a collectible interface

- Create a small `ICollectible` contract.
- Allow different objects to be collected through the same code.
- Compare the purpose of an interface with the base class.

### 5. Introduce events

- Raise an event when the score changes.
- Let the UI update in response to the event.
- Let audio respond to the same event without coupling it to scoring.

### 6. Store item settings with ScriptableObjects

- Move an item's name, colour, value, and icon into a data asset.
- Create new collectible variants without changing the scripts.
- Explain the difference between shared configuration and runtime state.

### 7. Add simple game states

- Introduce a `Playing`, `Won`, and `Paused` enum.
- Stop player movement after winning.
- Add pause and restart controls.

### 8. Extend and polish the game

- Add a timed mode.
- Add bonus collectibles.
- Add a high score.
- Improve feedback and presentation without greatly increasing scope.

## Final result

Students finish with an expanded version of their original collection game containing multiple collectible types, cleaner components, collection tracking, event-driven UI and audio, configurable item data, simple game states, a timed mode, and a high score.

## Save for later courses

Do not introduce these topics in this course:

- Enemy AI
- Complex state machines
- Generic object pools
- Saving and progression systems
- Multiplayer
- Large-scale game architecture

These can form later stages of the full Unity game-development pathway.
