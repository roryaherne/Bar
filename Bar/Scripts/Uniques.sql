﻿ALTER TABLE Places
ADD UNIQUE (Title)

GO

ALTER TABLE Products
ADD UNIQUE (Title)

GO

ALTER TABLE ProductStates
ADD UNIQUE (Title)

GO


ALTER TABLE ProductTypes
ADD UNIQUE (Title)

GO

ALTER TABLE Units
ADD UNIQUE (Title)

GO

ALTER TABLE Units
ADD UNIQUE (ShortTitle)

GO