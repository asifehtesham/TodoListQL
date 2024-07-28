# TodoListQL

based on youtube video https://www.youtube.com/watch?v=IoLtrxw98So

1. Get List
query{
	a:list(where: {id: {eq: 1}}){
		id, name,
		items{
			title,
			itemList{
				name
			}
		}
	},
	b:list(order: {name : DESC}){
		id, name,
		items{
			title
		}
	},
}

2. Get Items

query{
	item{
		id, title, description, isDone,
		itemList{
			name
		}		
	}
}

3. Add List item
mutation{
	addList(input: {name: "Studies"})
	{
		list{
			id, name
		}
	}
}

4. Add Item
mutation{
	addItem(input: {		
		title: "Study graphql",
		description: "Study graphql",
		isDone: true,
		listid: 4
	})
	{
		item{
			id, title, description
		}
	}
}
