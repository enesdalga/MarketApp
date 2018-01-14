Example Query
```
{
  getAllOrders{
    product{
      name,
      description,
      price
    },
    user{
      userId,
      fullName
    }
    
  }
}
```
Example Mutation
```
mutation($Product:ProductInputType!,$Id:Int!){
  updateProduct(Product:$Product,ProductId:$Id){
    name
  }
}
Variables
{
  "Id": 1,
  "Product": {
    "name": "",
    "description": "",
    "price": 1,
    "imagePath": "",
    "categoryId": 1
  }
}
```
