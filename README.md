# Rebase Training Repo

This Git repository gives you an example where you can train/experiment with Git's rebasing feature.

You can train two things here:

1. Rebase branch `rebase/feature/multiply` onto `rebase/master`.
1. Rebase and squash branch `rebase/feature/multiply` onto `rebase/master` (using interactive rebasing).

In both cases, there will (should) be a merge conflict that you need to resolve.

## Getting Started

Follow these instructions to get the repository into a state where you can train:

```
$ cd <an-empty-dir>
$ git clone -b rebase/master https://github.com/skrysmanski/rebase-training.git .
$ git checkout --track origin/rebase/feature/multiply
```

**Note:** If something went wrong, I recommend that you delete the whole directory and re-clone the repository before you try again.

## Rebase (without Squash) - in Sourcetree

1. Open the "Log / History" tab
1. Checkout **source branch** (`rebase/feature/multiply`)
1. Right-click **_head_ of target branch** (`rebase/master`) and select "Rebase..."
1. Resolve conflict via the "File Status" tab (Right-click on `Program.cs` and chose "Resolve Conflict")
1. In the menu choose "Action" -> "Continue Rebase"

## Rebase Interactively (with Squash) - in Sourcetree

Interactive rebasing allows you to squash, delete and reorder commits before rebasing them onto a different branch.

Unfortunately, Sourcetree contains an [ancient bug](https://jira.atlassian.com/browse/SRCTREEWIN-2493); so this feature doesn't fully work.

My current workaround: First do a *regular* rebase, then do the *interactive* rebase.

1. Rebase **source branch** (`rebase/feature/multiply`) on **target branch** (`rebase/master`)
1. Open the "Log / History" tab
1. Right-click the **_parent_ of oldest commit** you want to rebase interactively (here `5c3d0ea`) and select "Rebase children of xxx interactively..."
1. Modify the commits as desired (check out [this video](https://www.youtube.com/watch?v=mBCJCuU3p7I) for all the options)

## Pushing Changes - in Sourcetree

Once you're done you (probably) need to push your changes back to `origin`. Normally Git doesn't allow you to push these kind of changes.

Instead you need to "force push" them; ideally by using `--force-with-lease` instead of `--force`. You can read on the differences between those two in [this article](https://developer.atlassian.com/blog/2015/04/force-with-lease/).

To be able to do a "force push" with Sourcetree, this **needs to be enabled in the options**.

In the menu, go to "Tools" -> "Options" -> "Git" and check "Enable Force Push". Make sure to also check "Use Safe Force Push".

Then you can select "Force Push" in "Push" dialog. (No matter the name, this will automatically use `--force-with-lease` instead of `--force` when "Use Safe Force Push" is enabled in the options.)
