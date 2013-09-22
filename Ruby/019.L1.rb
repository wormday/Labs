class MyClass
	attr :a,true
end

MyClass1=Class.new do 
	def a
		puts "Block Method"
	end
end
o=MyClass1.new
puts MyClass1.superclass