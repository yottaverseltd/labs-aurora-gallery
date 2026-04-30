# AGENTS

Rules for humans and agents touching this repo.

## Prose

- No em-dashes. Use period, comma, colon, parens, or a line break.
- No AI-smell phrases: "Let's", "We will", "Here we", "Simply", "Essentially", "Imagine", "In essence", "At its core", "This function", "Now we".
- No tutorial tone. Senior voice. Short paragraphs.
- No emojis in repo-authored prose.

## Code

- Nullable enabled. Warnings-as-errors. Analyzer level latest.
- Comments explain why, not what. Only add a `// why` note for non-obvious invariants, constraints, or trade-offs.
- Colors resolve through tokens in `Styles/Tokens.xaml` and overlays in `Styles/Aurora.xaml`. Page XAML never hardcodes a brush for chrome.
- Motion durations resolve through resources in `Styles/Motion.xaml`. Runtime clamps durations to zero when reduced motion matches.
- File-scoped namespaces. `sealed` by default for leaf classes.

## Commits

- Imperative, lowercase subject.
- No trailing period on the subject.
- Body optional, wrap at 72.

## Forbidden

- Telemetry, analytics, third-party trackers.
- Network calls, auth. This repo is offline UI only.
- Brush, color, or duration literals in page XAML (specimens aside, token rows may display resolved values).
