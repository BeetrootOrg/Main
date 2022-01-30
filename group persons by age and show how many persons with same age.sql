select Age, count(*) as [number of persons]
from PersonsDB.dbo.Persons
group by Age