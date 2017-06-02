
import { PipeTransform, Pipe } from '@angular/core';
import { IProduct } from './product';

@Pipe({
    name: 'productFilter'
})

export class ProductFilterPipe implements PipeTransform {

    transform(value: IProduct[], filterBy: string): IProduct[] {
        var result: IProduct[] = [],
            filterBy = filterBy.toLowerCase() || null;
        
        // if filterBy != null filter the value;
        result = filterBy ? value.filter(function (product: IProduct) {
            return product.productName.toLowerCase().indexOf(filterBy) !== -1;
        }) : value;

        return result;
    }
}