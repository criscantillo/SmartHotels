# SmartHotels
API para reserva de habitaciones Smart

## Consideraciones
El modelo de usuarios es muy simple, extendiendo el programa, se puede usar Firebase, Cognito o algún otro proveedor Auth.

## Enumeraciones
Para algunos campos se definen tipos que simplifican el grabado y el acceso a los datos:

- User.UserType (1.Usuario Admin, 2.Cliente)
- Room.Type (1.Sencilla, 2.Doble, 3.Triple, 4.Familiar, 5.Suit)
