<?php

    $method = $_SERVER['REQUEST_METHOD'];

    $conexao = mysqli_connect("localhost","u522997124_root","craft127ca","u522997124_app"); 
	if (!$conexao)
		die ("Erro de conexão com localhost, o seguinte erro ocorreu -> ".mysqli_error());

	$banco = mysqli_select_db($conexao,"u522997124_app");
	if (!$banco)
        die ("Erro de conexão com banco de dados, o seguinte erro ocorreu -> ".mysqli_error());
    


    $query = "SELECT * FROM `mercado` WHERE 1";
	
	$result = mysqli_query($conexao, $query);
	
	$rows = array();
	$i = 0;
		
    while($r = mysqli_fetch_assoc($result)) {
		
		        $obj['results'][$i] = (object) [
  
			        'geometry'=>[
				        'location'=>['lat'=> $r['loc_lat'], 'lng'=>$r['loc_lng']], 
			    	    'viewport'=>['northeast' =>['lat'=> -45123, 'lng'=>-15350], 'southheast'=>['lat'=> -45123, 'lng'=>-15350]]
			       ],
			        'icon'=>'',
			        'id'=>$r['cnpj'],
			        'name'=>$r['nome'],
			        'opening_hours'=>['open_now'=> false],
		         	'photos'=>[['height'=> 608, 'html_attributions'=>[], 'photo_reference'=>'', 'width'=> 1280]],
		         	'place_id'=> '',
		        	'plus_code'=>[
		        		'compound_code'=> '', 
		        		'global_code'=>''
		        	],
		        	'rating'=> $r['estrelas'],
		         	'reference'=>'',
		         	'types'=>[ "bank", "atm", "finance", "point_of_interest", "establishment" ],
		        	'user_ratings_total'=> 2,
		        	'vicinity'=> $r['endereco'].",".$r['numero_ed']
	    	    ];
		
	        	$i++;		
            }

	echo json_encode($obj);
    
?>