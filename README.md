1. as a user i want to define schema so that i will define data type that will be stored
2. as a user i want to add data so that i can permanently store information
3. as a user i want to get all the data by schema so that i can use this info for some operations
4. as a user i want to paginate data so that i can take only small pages instead of everything

API:
1. define schema 
- POST api/schema/{name}
- body:
{
  fields: [
	{
		name: string!,
		type: string of { int,string,bool }!,
		required: bool?,
		default: string?
	}
  ]
}

2. get all data
- GET api/data/{schemaName}?pageSize=int&pageNum=int

3. add data to schema
- POST api/data/{schemaName}
- body:
{
	data: [
		{
			[key: string]: string
		}
	]
}

Example:
schema can be next:
{
  fields: [
	{
		name: "firstName",
		type: "string",
		required: true
	},
	{
		name: "address",
		type: "string"
	},
	{
		name: "age",
		type: "int",
		default: 42
	},
	{
		name: "verified",
		type: "bool",
		default: false
	}
  ]
}

add data:
{
	data: [
		{
			"firstName": "D",
			"age": 25,
			"verified": true
		},
		{
			"firstName": "DMDM",
			"age": null,
			"address": "Some address"
		},
		{
			"firstName": "SDHKSADHK"
		}
	]
}