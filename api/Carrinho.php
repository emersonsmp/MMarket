<?php

    $method = $_SERVER['REQUEST_METHOD'];

    $conexao = mysqli_connect("localhost","u522997124_root","craft127ca","u522997124_app"); 
	if (!$conexao)
		die ("Erro de conexão com localhost, o seguinte erro ocorreu -> ".mysqli_error());

	$banco = mysqli_select_db($conexao,"u522997124_app");
	if (!$banco)
        die ("Erro de conexão com banco de dados, o seguinte erro ocorreu -> ".mysqli_error());
    

    
    //ADICIONA ITEM AO CARRINHO
    if($method == 'POST'){
        
        $id_pedido = $_POST['id_pedido'];
        $cpf = $_POST['cpf'];
        $data = date('Y-m-d');
        $cod_barra = $_POST['cod_barra'];
        $cnpj = $_POST['cnpj'];
        $quant = $_POST['quant'];
        
        //SE AINDA NÃO POSSUI UM ID DE COMPRA
        if($id_pedido == 0){
            
            $query = "INSERT INTO `pedido`(`DataVenda`, `FlagEntrega`,`Cliente_cpf`) VALUES ('$data','0','$cpf')";
            $result = mysqli_query($conexao, $query); 
            
            $id_pedido = mysqli_insert_id($conexao);
        }
    
        //INSERE ITEM
        $query = "INSERT INTO `item`(`cod_barra`, `mercado_cnpj`, `Quantidade`) 
            VALUES ('$cod_barra','$cnpj', '$quant')";	
        
        $result = mysqli_query($conexao, $query);
        $item_id = mysqli_insert_id($conexao);
        
        //INSERE NA TABELA PEDIDO_ITEM
        $query = "INSERT INTO `pedido_item`(`Pedido_idpedido`, `Item_id`, `Item_cod_barra`, `Item_mercado_cnpj`) 
            VALUES ('$id_pedido','$item_id','$cod_barra','$cnpj')";

        $result = mysqli_query($conexao, $query);

        $resp = array('id_pedido'=>$id_pedido, 'cpf'=>$cpf);
        echo json_encode($resp);
    }
    
    //GET ITENS SACOLA
    if($method == 'GET'){
    
        $cpf  = $_GET['cpf' ];
        $cnpj = $_GET['cnpj'];
        
        $query = "SELECT pedido.idpedido, pedido.total, item.cod_barra, item.Quantidade, produto.nome, item.id
        FROM pedido INNER JOIN item INNER JOIN pedido_item INNER JOIN cliente INNER JOIN produto 
       
        ON pedido.idpedido = pedido_item.Pedido_idpedido
        AND pedido_item.Item_cod_barra = item.cod_barra 
        AND item.cod_barra = produto.cod_barra 
        AND pedido.Cliente_cpf = cliente.cpf 
        AND item.id = pedido_item.Item_id 
       
        WHERE pedido.FlagEntrega = 0 
        AND pedido.Cliente_cpf = $cpf 
        AND pedido_item.Item_mercado_cnpj = $cnpj";
       
        $result = mysqli_query($conexao, $query);
	
	    $i = 0;
        while($r = mysqli_fetch_assoc($result)) {
		
		    if($i== 0){
		        $obj['id'] = $r['idpedido'];
		        $obj['total'] =  $r['total'];
		    }
		
		    $obj['itens'][$i] = (object) [ 'nomeProduto'  => $r['nome'], 'quantidade' => $r['Quantidade'], 'itemid' => $r['id'] ];
		    $i++;
        }
        
        echo json_encode($obj);
    }
?>