# TODO: Make this a fluent function in RT
photograph-name-text = Це фотографія { PROPER($entity) ->
    *[false] { INDEFINITE($entity) } { $entity }
     [true] { $entity }
    }.
photograph-name-text-empty = Це фотографія.
photograph-name-text-photograph = Це фотографія іншої фотографії.
